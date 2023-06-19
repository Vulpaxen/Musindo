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
    public class ArtistHandler
    {
        static ArtistRepository ArtistRepo = new ArtistRepository();

        public bool uploadArtist(String ArtName, FileUpload upImage)
        {
            Guid uuid = Guid.NewGuid();
            string filename = uuid.ToString() + System.IO.Path.GetExtension(upImage.PostedFile.FileName);
            string directoryPath = "Assets/Artists/";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, directoryPath, filename);
            upImage.SaveAs(filePath);

            if(ArtistRepo.InsertArtist(ArtName, filename) != null)
            {
                return true;
            }

            return false;
        }

        public bool updateArtist(int ArtistID, String ArtName, FileUpload upImage)
        {
            Guid uuid = Guid.NewGuid();
            string filename = uuid.ToString() + System.IO.Path.GetExtension(upImage.PostedFile.FileName);
            string directoryPath = "Assets/Artists/";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, directoryPath, filename);
            upImage.SaveAs(filePath);

            if(ArtistRepo.UpdateArtist(ArtistID, ArtName, filename) != null)
            {
                return true;
            }

            return false;
        }

        public bool isArtistNameUnique(string name)
        {
            if (ArtistRepo.getArtistByName(name) != null)
            {
                return false;
            }

            return true;
        }

        public Artist deleteArtist(int artistID)
        {
            return ArtistRepo.DeleteArtist(artistID);
        }
        public Artist GetArtistByArtistID(int id)
        {
            return ArtistRepo.GetArtistByID(id);
        }

        public List<Artist> GetAllArtist()
        {
            return ArtistRepo.GetArtists();
        }
        public List<Artist> GetArtistsByArtistID(int id)
        {
            return ArtistRepo.GetArtistsByArtistID(id);
        }
    }
}