using System.Collections.Generic;

namespace MusicLibaryApp
{
    internal interface IDatastorage
    {
        void SaveMusic(MusicEntry music);

        void DeleteMusic(string musicTitle);

        MusicEntry ViewMusic(string musicTitle);

        List<MusicEntry> ListMusic();
    }
}