using KpopZstation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpopZstation.Factory
{
    public class AlbumFactory
    {
        public static Album addAlbum(int artistID, String albumName, String albumImage, int albumPrice, int albumStock, String albumDescription)
        {
            Album newAlbum = new Album();
            newAlbum.ArtistID = artistID;
            newAlbum.Albumname = albumName;
            newAlbum.AlbumImage = albumImage;
            newAlbum.AlbumPrice = albumPrice;
            newAlbum.AlbumStock = albumStock;
            newAlbum.AlbumDescription = albumDescription;
            return newAlbum;
        }
    }
}