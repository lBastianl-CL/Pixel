using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace Pixel.FurnitureCreator
{
    public partial class MainForm : Form
    {
        public int nextImageId = 0;
        private Furniture furniture = new Furniture();
        private Dictionary<int, ItemImage> images = new Dictionary<int, ItemImage>();
        private Bitmap tile;

        public MainForm()
        {
            InitializeComponent();
        }

        private void addImage_Click(object sender, System.EventArgs e)
        {
            try
            {
                OpenFileDialog openImage = new OpenFileDialog();
                openImage.Filter = "Image Files (PNG)|*.png";
                openImage.ShowDialog();

                images.Add(nextImageId, new ItemImage() { Id = nextImageId, Image = Image.FromFile(openImage.FileName) });
                imagesList.Items.Add(nextImageId);
                nextImageId++;

                switch(MessageBox.Show("Do you want flipped image as well?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    case DialogResult.Yes:
                        images.Add(nextImageId, new ItemImage() { Id = nextImageId, Image = Image.FromFile(openImage.FileName) }); ;
                        images[nextImageId].Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        imagesList.Items.Add(nextImageId);
                        nextImageId++;
                        break;
                }
            }
            catch
            {
            }
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            tile = new Bitmap(Image.FromFile("tile.png"));
            drawPreview(-1);
        }

        private void infoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Software developed by Manuel (Pixel.JS Team)");
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private int selectedItem = -1;

        private void imagesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(imagesList.SelectedItem.ToString());
                ItemImage item = images[id];
                selectedItem = id;
                rotation.Text = item.Rotation.ToString();
                state.Text = item.State.ToString();
                layer.Text = item.Layer.ToString();
                depth.Text = item.Depth.ToString();
                offX.Value = item.offX;
                offY.Value = item.offY;
                itemPreview.BackgroundImage = item.Image;

                drawPreview(item.State);
            }
            catch
            {

            }
        }


        int sizeX = 252;
        int sizeY = 256;
        int centerX = 252 / 2;
        int centerY = 256 / 2;

        private void drawPreview(int state)
        {
            ItemImage img = null;

            try
            {
                img = images[selectedItem];
            }
            catch
            {
                img = null;
            }

            if (img == null)
                return;

            var target = new Bitmap(sizeX, sizeY, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(target);
            graphics.CompositingMode = CompositingMode.SourceOver;

            drawImageCenter(graphics, tile, getX(0, 0), getY(0, 0));
            drawImageCenter(graphics, tile, getX(1, 0), getY(1, 0));
            drawImageCenter(graphics, tile, getX(2, 0), getY(2, 0));
            drawImageCenter(graphics, tile, getX(0, 1), getY(0, 1));
            drawImageCenter(graphics, tile, getX(1, 1), getY(1, 1));
            drawImageCenter(graphics, tile, getX(2, 1), getY(2, 1));
            drawImageCenter(graphics, tile, getX(0, 2), getY(0, 2));
            drawImageCenter(graphics, tile, getX(1, 2), getY(1, 2));
            drawImageCenter(graphics, tile, getX(2, 2), getY(2, 2));

            if(state >= 0)
            {
                foreach (ItemImage itemPart in images.Values.Where(x => x.State == state && x.Rotation == img.Rotation).OrderBy(x => x.Depth))
                {
                    drawImageCenter(graphics, new Bitmap(itemPart.Image), getX(1, 1) - itemPart.offX, getY(1, 1) - itemPart.offY);
                }
            }

            preview.BackgroundImage = target;
        }

        private int getX(int x, int y)
        {
            return centerX + (32 * y) - (32 * x);
        }

        private int getY(int x, int y)
        {
            return centerY + (16 * y) + (16 * x);
        }

        private void drawImageCenter(Graphics graphics, Bitmap image, int x, int y)
        {
            graphics.DrawImage(image, x - (image.Width / 2), y - (image.Height / 2));
        }

        private void reloadNames()
        {
           
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            drawPreview(0);
        }

        private void offX_ValueChanged(object sender, EventArgs e)
        {
            if (selectedItem == -1)
                return;

            images[selectedItem].offX = (int) offX.Value;

            drawPreview(images[selectedItem].State);
        }

        private void offY_ValueChanged(object sender, EventArgs e)
        {
            if (selectedItem == -1)
                return;

            
            drawPreview(images[selectedItem].State);
        }

        private void preview_Click(object sender, EventArgs e)
        {

        }

        private void saveItemInfo_Click(object sender, EventArgs e)
        {
            if (selectedItem == -1)
                return;

            images[selectedItem].Rotation = int.Parse(rotation.Text);
            images[selectedItem].State = int.Parse(state.Text);
            images[selectedItem].Layer = int.Parse(layer.Text);
            images[selectedItem].offY = (int)offY.Value;
            images[selectedItem].Depth = int.Parse(depth.Text);
            images[selectedItem].offX = (int)offX.Value;
            drawPreview(images[selectedItem].State);

            MessageBox.Show("Saved.");
        }

        private void offX_ValueChanged_2(object sender, EventArgs e)
        {
            if (selectedItem == -1)
                return;
            images[selectedItem].offX = (int)offX.Value;
            drawPreview(images[selectedItem].State);
        }

        private void offY_ValueChanged_1(object sender, EventArgs e)
        {
            if (selectedItem == -1)
                return;
            images[selectedItem].offY = (int)offY.Value;
            drawPreview(images[selectedItem].State);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (furniture.Name.Length == 0)
                return;

            imageNames.Items.Clear();

            foreach(ItemImage partImage in images.Values)
            {
                partImage.RealName = furniture.Name + "_" + partImage.Rotation + "_" + partImage.Layer + "_" + partImage.State;
                imageNames.Items.Add(furniture.Name + "_" + partImage.Rotation + "_" + partImage.Layer + "_" + partImage.State);
            }
        }

        private void furnoName_TextChanged(object sender, EventArgs e)
        {
            furniture.Name = furnoName.Text;
        }

        private void furnoStates_TextChanged(object sender, EventArgs e)
        {
            furniture.States = (int)states.Value;
        }

        private void furnoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            furniture.Type = furnoType.SelectedItem.ToString();
        }

        private void depth_TextChanged(object sender, EventArgs e)
        {
            if (selectedItem == -1)
                return;
            images[selectedItem].Depth = int.Parse(depth.Text);
            drawPreview(images[selectedItem].State);
        }

        private void layer_TextChanged(object sender, EventArgs e)
        {
            if (selectedItem == -1)
                return;
            images[selectedItem].Layer = int.Parse(layer.Text);
            drawPreview(images[selectedItem].State);
        }

        private void state_TextChanged(object sender, EventArgs e)
        {
            if (selectedItem == -1)
                return;
            images[selectedItem].State = int.Parse(state.Text);
            drawPreview(images[selectedItem].State);
        }

        private void rotation_TextChanged(object sender, EventArgs e)
        {
            if (selectedItem == -1)
                return;
            images[selectedItem].Rotation = int.Parse(rotation.Text);
            drawPreview(images[selectedItem].State);
        }

        private void imageNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            try
            {
                string itemName = imageNames.SelectedItem.ToString();
                ItemImage item = images.Values.FirstOrDefault(x => x.RealName == itemName);

                if (item == null)
                    return;

                selectedItem = item.Id;
                rotation.Text = item.Rotation.ToString();
                state.Text = item.State.ToString();
                layer.Text = item.Layer.ToString();
                depth.Text = item.Depth.ToString();
                offX.Value = item.offX;
                offY.Value = item.offY;
                itemPreview.BackgroundImage = item.Image;

                drawPreview(item.State);
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string itemName = imageNames.SelectedItem.ToString();
                ItemImage item = images.Values.FirstOrDefault(x => x.RealName == itemName);

                if (item == null)
                    return;

                Clipboard.SetText(item.RealName);

            }
            catch
            {

            }
        }

        private Dictionary<int, Animation> animations = new Dictionary<int, Animation>();

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (animations.ContainsKey((int)animationId.Value))
                    return;

                string _count = Interaction.InputBox("How much time we've to repeat the animation? (-1 = loop)", "", "", -1, -1);
                int count = int.Parse(_count);

                Animation anim = new Animation();
                anim.Id = (int) animationId.Value;
                anim.Repeat = count;
                animations.Add(anim.Id, anim);
                animationsList.Items.Add(anim.Id.ToString());
            }
            catch
            {

            }
        }

        private Animation selectedAnim = null;

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedAnim = animations[int.Parse(animationsList.SelectedItem.ToString())];
                frames.Items.Clear();
                foreach (List<string> _frames in selectedAnim.AnimationFrames)
                {
                    string r = "";
                    foreach (string frame in _frames)
                        r += frame + ";";

                    r = r.Substring(0, r.Length - 1);
                    frames.Items.Add(r);
                }
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedAnim == null)
                    return;
                frames.Items.Add(frame.Text);

                List<string> fr = new List<string>();
                if (frame.Text.Contains(';'))
                {
                    string[] _fr = frame.Text.Split(';');
                    foreach (string f in _fr)
                        fr.Add(f);
                }
                else fr.Add(frame.Text);

                selectedAnim.AnimationFrames.Add(fr);
            }
            catch
            {

            }
        }

        private int currentFrame = 0;
        private int currentCount = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            currentCount = 0;
            currentFrame = -1;
            anim.Start();
        }

        private void anim_Tick(object sender, EventArgs e)
        {
            currentFrame++;
            if (currentFrame >= selectedAnim.AnimationFrames.Count)
            {
                currentFrame = 0;
                currentCount++;

                if (selectedAnim.Repeat != -1 && currentCount >= selectedAnim.Repeat)
                {
                    anim.Stop();
                    MessageBox.Show("Animation ended!");
                }
            }


            drawAnim();
        }

        private void drawAnim()
        {
            var target = new Bitmap(sizeX, sizeY, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(target);
            graphics.CompositingMode = CompositingMode.SourceOver;

            drawImageCenter(graphics, tile, getX(0, 0), getY(0, 0));
            drawImageCenter(graphics, tile, getX(1, 0), getY(1, 0));
            drawImageCenter(graphics, tile, getX(2, 0), getY(2, 0));
            drawImageCenter(graphics, tile, getX(0, 1), getY(0, 1));
            drawImageCenter(graphics, tile, getX(1, 1), getY(1, 1));
            drawImageCenter(graphics, tile, getX(2, 1), getY(2, 1));
            drawImageCenter(graphics, tile, getX(0, 2), getY(0, 2));
            drawImageCenter(graphics, tile, getX(1, 2), getY(1, 2));
            drawImageCenter(graphics, tile, getX(2, 2), getY(2, 2));

            foreach(string frame in selectedAnim.AnimationFrames[currentFrame])
            {
                try
                {
                    ItemImage itemImage = images.Values.FirstOrDefault(x => x.RealName == frame);
                    if(itemImage != null)
                    {
                        drawImageCenter(graphics, new Bitmap(itemImage.Image), getX(1, 1) - itemImage.offX, getY(1, 1) - itemImage.offY);
                    }
                }
                catch
                {

                }
            }

            preview.BackgroundImage = target;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            anim.Stop();
        }

        private void saveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog selectDirectory = new FolderBrowserDialog();
            selectDirectory.ShowDialog();

            string NEW_LINE = Environment.NewLine;
            string SPACER = "    ";

            string result = "";
            result += "{" + NEW_LINE;

            result += $"{SPACER}\"name\": \"{furniture.Name}\", {NEW_LINE}";
            result += $"{SPACER}\"type\": \"{furniture.Type}\", {NEW_LINE}";
            result += $"{SPACER}\"layers\": \"{furniture.Layers.ToString()}\", {NEW_LINE}";


            result += $"{SPACER}\"offset\": {{ {NEW_LINE}";
            int count = 0;
            foreach (ItemImage image in images.Values)
            {
                count++;
                if (count < images.Count)
                    result += $"{SPACER}{SPACER}\"{image.RealName}\": {{ \"x\": {image.offX}, \"y\": {image.offY}, \"depth\": {image.Depth} }}, {NEW_LINE}";
                else result += $"{SPACER}{SPACER}\"{image.RealName}\": {{ \"x\": {image.offX}, \"y\": {image.offY}, \"depth\": {image.Depth} }}  {NEW_LINE}";
            }
            if(animations.Count > 0)
                result += $"{SPACER}}}, {NEW_LINE}";
            else result += $"{SPACER}}} {NEW_LINE}";



            if (animations.Count > 0)
            {
                result += $"{SPACER}\"animation\": {{ {NEW_LINE}";

                count = 0;
                foreach (Animation anim in animations.Values)
                {

                    count++;
                    //if(count < animations.Count)
                    result += $"{SPACER}{SPACER}\"{anim.Id}\": {furniture.Layers}{NEW_LINE}";
                    result += $"{SPACER}{SPACER}{{ {NEW_LINE}";
                    result += $"{SPACER}{SPACER}{SPACER}\"repeat\": {anim.Repeat},{NEW_LINE}";
                    result += $"{SPACER}{SPACER}{SPACER}\"frames\":{NEW_LINE}";
                    result += $"{SPACER}{SPACER}{SPACER}[{NEW_LINE}";
                    int fin = 0;
                    foreach (List<string> frames in anim.AnimationFrames)
                    {
                        string toAdd = "[";
                        foreach (string frame in frames)
                        {
                            toAdd += "\"" + frame + "\", ";
                        }
                        toAdd = toAdd.Substring(0, toAdd.Length - 2);
                        toAdd += "]";
                        fin++;
                        if (fin == anim.AnimationFrames.Count)
                            result += $"{SPACER}{SPACER}{SPACER}{SPACER}{toAdd}{NEW_LINE}";
                        else result += $"{SPACER}{SPACER}{SPACER}{SPACER}{toAdd},{NEW_LINE}";
                    }
                    result += $"{SPACER}{SPACER}{SPACER}]{NEW_LINE}";
                    result += $"{SPACER}{SPACER}}} {NEW_LINE}";
                }

                result += $"{SPACER}}} {NEW_LINE}";
            }

            result += "}";

            File.WriteAllText(selectDirectory.SelectedPath + "\\" + furniture.Name + ".json", result);
            
            // PNG Images spritesheet
            var target = new Bitmap(GetResultWidth(), GetMaxHeight(), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var graphics = Graphics.FromImage(target);
            graphics.CompositingMode = CompositingMode.SourceOver;

            int nextX = 0;
            foreach (ItemImage image in images.Values)
            {
                Bitmap bImage = new Bitmap(image.Image);
                graphics.DrawImage(bImage, nextX, 0);
                image.AtlasX = nextX;
                image.AtlasY = 0;
                nextX += bImage.Width;
            }
            target.Save(selectDirectory.SelectedPath + "\\" + furniture.Name + "_spritesheet.png", ImageFormat.Png);

            // Atlas JSON
            string atlas = "";
            atlas += $"{{ {NEW_LINE}";
            atlas += $"{SPACER}\"frames\": [{NEW_LINE}";

            int c = 0;
            foreach(ItemImage image in images.Values)
            {
                c++;
                atlas += $"{SPACER}{SPACER}{{{NEW_LINE}";
                atlas += $"{SPACER}{SPACER}{SPACER}\"filename\": \"{image.RealName}\",{NEW_LINE}";
                atlas += $"{SPACER}{SPACER}{SPACER}\"frame\": {{ \"x\": {image.AtlasX}, \"y\": {image.AtlasY}, \"w\": {image.Image.Width}, \"h\": {image.Image.Height} }},{NEW_LINE}";
                atlas += $"{SPACER}{SPACER}{SPACER}\"rotated\": false,{NEW_LINE}";
                atlas += $"{SPACER}{SPACER}{SPACER}\"trimmed\": false,{NEW_LINE}";
                atlas += $"{SPACER}{SPACER}{SPACER}\"spriteSourceSize\": {{ \"x\": 0, \"y\": 0, \"w\": {image.Image.Width}, \"h\": {image.Image.Height} }},{NEW_LINE}";
                atlas += $"{SPACER}{SPACER}{SPACER}\"sourceSize\": {{ \"w\": {image.Image.Width}, \"h\": {image.Image.Height} }},{NEW_LINE}";
                atlas += $"{SPACER}{SPACER}{SPACER}\"pivot\": {{ \"x\": 0, \"y\": 0 }}{NEW_LINE}";
                if(images.Count == c)
                    atlas += $"{SPACER}{SPACER}}}{NEW_LINE}";
                else atlas += $"{SPACER}{SPACER}}},{NEW_LINE}";
            }

            atlas += $"{SPACER}]{NEW_LINE}";
            atlas += "}";

            File.WriteAllText(selectDirectory.SelectedPath + "\\" + furniture.Name + "_atlas.json", atlas);
            MessageBox.Show("File saved");
        }

        private int GetMaxHeight()
        {
            int max = 0;
            foreach(ItemImage image in images.Values)
            {
                if (image.Image.Height > max)
                    max = image.Image.Height; 
            }
            return max;
        }

        private int GetResultWidth()
        {
            int result = 0;
            foreach (ItemImage image in images.Values)
            {
                result += image.Image.Width;
            }
            return result;
        }

        private void layers_ValueChanged(object sender, EventArgs e)
        {
            furniture.Layers = (int)layers.Value; 
        }
    }
}
