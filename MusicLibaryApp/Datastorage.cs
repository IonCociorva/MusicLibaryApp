using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibaryApp

    //Data storage Class
{
    class Datastorage : IDatastorage
    {
        private List<MusicEntry> listOfMusic;

        public Datastorage()
        {
            listOfMusic = new List<MusicEntry>();
        }
        public void DeleteMusic(string musicTitle)
        {
            foreach(var music in listOfMusic)
            {
                if (music.MusicTitle.Equals(musicTitle))
                {
                    listOfMusic.Remove(music);
                    break;
                }
            }
        }

        public void SaveMusic(MusicEntry music)
        {
            if (!listOfMusic.Contains(music))
            {
                listOfMusic.Add(music);
            }
        }

        public MusicEntry ViewMusic(string musicTitle)
        {
            foreach (var viewmusic in listOfMusic)
            {
                if (musicTitle.Equals(viewmusic.MusicTitle))
                {
                    return viewmusic;
                }
            }

            return null;
        }

        public List<MusicEntry> ListMusic()
        {
            return listOfMusic;
        }
    }
}
