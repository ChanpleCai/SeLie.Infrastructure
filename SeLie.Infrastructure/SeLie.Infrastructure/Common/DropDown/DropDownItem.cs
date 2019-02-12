using SeLie.Infrastructure.Base;

namespace SeLie.Infrastructure.Common
{
    public class DropDownItem : EntityLevelBase
    {
        public string ItemDesciption { get; set; } = "";

        public bool ReadOnly { get; set; } = false;
    }
}
