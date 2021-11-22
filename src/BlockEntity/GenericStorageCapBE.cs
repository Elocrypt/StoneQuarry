using System.Text;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.API.MathTools;

namespace StoneQuarry
{
    public class GenericStorageCapBE : BlockEntity
    {
        public BlockPos core = null;

        public override void FromTreeAttributes(ITreeAttribute tree, IWorldAccessor worldAccessForResolve)
        {
            if (tree.HasAttribute("capx"))
            {
                core = new BlockPos(tree.GetInt("capx"), tree.GetInt("capy"), tree.GetInt("capz"));
            }
            base.FromTreeAttributes(tree, worldAccessForResolve);
        }

        public override void ToTreeAttributes(ITreeAttribute tree)
        {
            if (core != null)
            {
                tree.SetInt("capx", core.X);
                tree.SetInt("capy", core.Y);
                tree.SetInt("capz", core.Z);
            }
            base.ToTreeAttributes(tree);
        }

        public override void GetBlockInfo(IPlayer forPlayer, StringBuilder dsc)
        {
            var coreBE = Api.World.BlockAccessor.GetBlockEntity(core);
            if (coreBE != null) coreBE.GetBlockInfo(forPlayer, dsc);
        }
    }

}