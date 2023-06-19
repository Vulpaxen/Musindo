using KpopZstation.Model;
using KpopZstation.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace KpopZstation.Handler
{
    public class AlbumHandler
    {
        AlbumRepository AlbumRepo = new AlbumRepository();
        public Album uploadAlbum(int ArtistID, String AlbName, String AlbDesc, int AlbPrice, int AlbStock, FileUpload upImage)
        {
            Guid uuid = Guid.NewGuid();
            string filename = uuid.ToString() + System.IO.Path.GetExtension(upImage.PostedFile.FileName);
            string directoryPath = "Assets/Albums/";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, directoryPath, filename);
            upImage.SaveAs(filePath);

            return AlbumRepo.InsertAlbum(ArtistID, AlbName, filename, AlbPrice, AlbStock, AlbDesc);
        }

        public Album updateAlbum(int AlbumID, String AlbName, String AlbDesc, int AlbPrice, int AlbStock, FileUpload upImage)
        {
            Guid uuid = Guid.NewGuid();
            string filename = uuid.ToString() + System.IO.Path.GetExtension(upImage.PostedFile.FileName);
            string directoryPath = "Assets/Albums/";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, directoryPath, filename);
            upImage.SaveAs(filePath);

            return AlbumRepo.UpdateAlbum(AlbumID, AlbName, filename, AlbPrice, AlbStock, AlbDesc);
        }

        public Album deleteAlbum(int albumID)
        {
            return AlbumRepo.DeleteAlbum(albumID);
        }

        public List<Album> GetAlbumsByArtistID(int id)
        {
            return AlbumRepo.GetAlbumsByArtistID(id);
        }

        public Album GetAlbumByAlbumID(int id)
        {
            return AlbumRepo.GetAlbumByID(id);
        }
    }
}