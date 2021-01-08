using Pixel.Server.Pixel.Items.Interactions;
using Pixel.Server.Pixel.Items.Interactions.Interactors;
using System.Collections.Generic;

namespace Pixel.Server.Pixel.Items
{
    public class Item
    {
        public int Id, Width, Length, InteractionCount;
        public string FurnidataName;
        public bool CanStack, CanSit, CanWalk;
        public double Height;
        public InteractionType Interaction;
        public List<double> MultiHeight = new List<double>();
        public int[] Rotations;

        public InteractionType GetInteraction(string Type)
        {
            switch(Type.Trim().ToLower())
            {
                default: return InteractionType.DEFAULT;
            }
        }

        public InteractorInterface GetInteractor()
        {
            switch (Interaction)
            {
                case InteractionType.DEFAULT:
                    return new DefaultInteractor();

                default: 
                    return new DefaultInteractor();
            }
        }
    }
}
