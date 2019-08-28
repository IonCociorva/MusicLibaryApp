using System.Collections.Generic;

namespace MusicLibaryApp
    //IDataStorage.cs
{
    internal interface IDatastorage
    {
        void SaveMusic(MusicEntry music);

        void DeleteMusic(string musicTitle);

        MusicEntry ViewMusic(string musicTitle);

        //list music entry
        List<MusicEntry> ListMusic();

    }
}