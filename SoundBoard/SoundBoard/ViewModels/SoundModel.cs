using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            Animals = CreateGroup("animals");
            Cartoons = CreateGroup("cartoons");
            Taunts = CreateGroup("taunts");
            Warnings = CreateGroup("warnings");

            IsDataLoaded = true;
        }

        private SoundGroup CreateGroup(string groupName)
        {
            SoundGroup data = new SoundGroup { Title = groupName };

            foreach (var soundFile in Directory.GetFiles("Assets/audio/" + groupName + "/"))
            {
                data.Items.Add(new SoundData { FilePath = soundFile, Title = Path.GetFileName(soundFile) });
            }
            return data;
        }  
    }
}
