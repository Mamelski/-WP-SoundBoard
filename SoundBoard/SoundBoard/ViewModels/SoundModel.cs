using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundBoard.ViewModels
{
    public class SoundModel
    {
        public SoundGroup CustomSounds { get; set; }
        public SoundGroup Animals { get; set; }
        public SoundGroup Cartoons { get; set; }
        public SoundGroup Taunts { get; set; }
        public SoundGroup Warnings { get; set; }

        public bool IsDataLoaded { get; set; }

        public void LoadData()
        {
            // Load data into the model
            IsDataLoaded = true;
        }
    
    }
}
