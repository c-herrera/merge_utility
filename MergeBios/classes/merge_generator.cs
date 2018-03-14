using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeBios
{

    enum MERGE_ARCH
    {
        NOARCH, x32,x64
    };

    enum LFP_OPTIONS
    {
        eDP,MIPI
    };

    /// <summary>
    /// Class to substitute merge script
    /// </summary>
    class MergeGenerator
    {

        private string IFWI_Path;
        private string Preboot_Path;
        private string Tools_Path;

        private string IFWI_version;
        private string PReboot_Path;

        private string VBT_path;
        private string VBT_Mod_Path;
       
        /// <summary>
        /// Class contruct
        /// </summary>
        public MergeGenerator()
        {

        }


    }
}
