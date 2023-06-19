using KpopZstation.Handler;
using KpopZstation.Model;
using KpopZstation.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace KpopZstation.Controller
{
    public class ArtistController
    {
        ArtistHandler handler = new ArtistHandler();
        public string ArtistValidation(string ArtName, FileUpload upImage)
        {


            return "Success";
        }

        public bool InsertArtist(InsertArtist view, string ArtName, FileUpload upImage)
        {
            if (ArtName.Equals(""))
            {
                view.ErrorMessage = "Please fill the Artist Name!";
                return false;
            }
            else if (ArtName.Length > 50)
            {
                view.ErrorMessage = "Artist name must be under 50 characters!";
                return false;
            }
            else if (!handler.isArtistNameUnique(ArtName))
            {
                view.ErrorMessage = "Artist name must be unique!";
                return false;
            }

            if (upImage.PostedFile.FileName.Equals(""))
            {
                view.ErrorMessage = "Please choose Artist Image!";
                return false;
            }

            else if (upImage.PostedFile.ContentLength >= 2000000)
            {
                view.ErrorMessage = "Image file size must be lower than 2MB";
                return false;
            }

            else
            {
                String[] validTypes = { ".png", ".jpg", ".jpeg", ".jfif" };
                bool isValidFile = false;
                String ext = System.IO.Path.GetExtension(upImage.PostedFile.FileName);

                for (var i = 0; i < validTypes.Length; i++)
                {
                    if (ext == validTypes[i])
                    {
                        isValidFile = true;
                        break;
                    }
                }

                if (!isValidFile)
                {
                    view.ErrorMessage = "Image file extension must be .png, .jpg, .jpeg, or .jfif";
                    return false;
                }
            }

            return handler.uploadArtist(ArtName, upImage);
        }

        public bool UpdateArtist(UpdateArtist view, int ArtistID, string ArtName, FileUpload upImage)
        {
            if (ArtName.Equals(""))
            {
                view.ErrorMessage = "Please fill the Artist Name!";
                return false;
            }
            else if (ArtName.Length > 50)
            {
                view.ErrorMessage = "Artist name must be under 50 characters!";
                return false;
            }
            else if (!handler.isArtistNameUnique(ArtName))
            {
                view.ErrorMessage = "Artist name must be unique!";
                return false;
            }

            if (upImage.PostedFile.FileName.Equals(""))
            {
                view.ErrorMessage = "Please choose Artist Image!";
                return false;
            }

            else if (upImage.PostedFile.ContentLength >= 2000000)
            {
                view.ErrorMessage = "Image file size must be lower than 2MB";
                return false;
            }

            else
            {
                String[] validTypes = { ".png", ".jpg", ".jpeg", ".jfif" };
                bool isValidFile = false;
                String ext = System.IO.Path.GetExtension(upImage.PostedFile.FileName);

                for (var i = 0; i < validTypes.Length; i++)
                {
                    if (ext == validTypes[i])
                    {
                        isValidFile = true;
                        break;
                    }
                }

                if (!isValidFile)
                {
                    view.ErrorMessage = "Image file extension must be .png, .jpg, .jpeg, or .jfif";
                    return false;
                }
            }

            return handler.updateArtist(ArtistID, ArtName, upImage);
        }

        public List<Artist> GetAllArtistsByArtistID(int id)
        {
            return handler.GetArtistsByArtistID(id);
        }

        public List<Artist> GetAllArtists()
        {
            return handler.GetAllArtist();
        }

        public Artist GetArtistByArtistID(int id)
        {
            return handler.GetArtistByArtistID(id);
        }

        public Artist DeleteArtist(int id)
        {
            return handler.deleteArtist(id);
        }

        public string AddQuantity(string curr)
        {
            int add = Convert.ToInt32(curr) + 1;
            return Convert.ToString(add);
        }

        public string RemoveQuantity(string curr)
        {
            int remove = Convert.ToInt32(curr) - 1;
            return Convert.ToString(remove);
        }

        public Boolean AddButtonValidation(string curr, string stock)
        {
            int add = Convert.ToInt32(curr);
            int CurrStock = Convert.ToInt32(stock);

            if (add >= CurrStock)
            {
                return false;
            }

            else return true;
        }

        public Boolean RemoveButtonValidation(string curr)
        {
            int remove = Convert.ToInt32(curr);
            if (remove <= 1)
            {
                return false;
            }
            else return true;
        }
    }
}