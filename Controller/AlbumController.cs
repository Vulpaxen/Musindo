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
    public class AlbumController
    {
        AlbumHandler handler = new AlbumHandler();

        public Album InsertAlbum(InsertAlbum view, int ArtistID, string AlbName, string AlbDesc, string AlbPrice, string AlbStock, FileUpload upImage)
        {
            if (AlbName.Equals(""))
            {
                view.ErrorMessage = "Please fill the Album Name!";
                return null;
            }
            else if (AlbName.Length > 50)
            {
                view.ErrorMessage = "Album name must be under 50 characters!";
                return null;
            }

            else if (AlbDesc.Equals(""))
            {
                view.ErrorMessage = "Please fill the Album Description!";
                return null;
            }
            else if (AlbDesc.Length > 255)
            {
                view.ErrorMessage = "Album description must be under 255 characters!";
                return null;
            }

            else if (AlbPrice.Equals(""))
            {
                view.ErrorMessage = "Please fill the Album Price!";
                return null;
            }

            var isNumeric = int.TryParse(AlbPrice, out int price);
            if(!isNumeric)
            {
                view.ErrorMessage = "Album price must be numeric";
                return null;
            }
            if (price < 100000 || price > 1000000)
            {
                view.ErrorMessage = "Album price must be between 100000 and 1000000";
                return null;
            }

            if (AlbStock.Equals(""))
            {
                view.ErrorMessage = "Please fill the Album Stock!";
                return null;
            }

            var isStockNumeric = int.TryParse(AlbStock, out int stock);
            if (!isStockNumeric)
            {
                view.ErrorMessage = "Album stock must be numeric";
                return null;
            }
            if (stock <= 0)
            {
                view.ErrorMessage = "Album stock must be more than 0";
                return null;
            }

            if (upImage.PostedFile.FileName.Equals(""))
            {
                view.ErrorMessage = "Please choose Album Image!";
                return null;
            }

            else if (upImage.PostedFile.ContentLength >= 2000000)
            {
                view.ErrorMessage = "Image file size must be lower than 2MB";
                return null;
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
                    return null;
                }
            }

            return handler.uploadAlbum(ArtistID, AlbName, AlbDesc, price, stock, upImage);
        }

        public Album UpdateAlbum(UpdateAlbum view, int AlbumID, string AlbName, string AlbDesc, string AlbPrice, string AlbStock, FileUpload upImage)
        {
            if (AlbName.Equals(""))
            {
                view.ErrorMessage = "Please fill the Album Name!";
                return null;
            }
            else if (AlbName.Length > 50)
            {
                view.ErrorMessage = "Album name must be under 50 characters!";
                return null;
            }

            else if (AlbDesc.Equals(""))
            {
                view.ErrorMessage = "Please fill the Album Description!";
                return null;
            }
            else if (AlbDesc.Length > 255)
            {
                view.ErrorMessage = "Album description must be under 255 characters!";
                return null;
            }

            else if (AlbPrice.Equals(""))
            {
                view.ErrorMessage = "Please fill the Album Price!";
                return null;
            }

            var isNumeric = int.TryParse(AlbPrice, out int price);
            if (!isNumeric)
            {
                view.ErrorMessage = "Album price must be numeric";
                return null;
            }
            if (price < 100000 || price > 1000000)
            {
                view.ErrorMessage = "Album price must be between 100000 and 1000000";
                return null;
            }

            if (AlbStock.Equals(""))
            {
                view.ErrorMessage = "Please fill the Album Stock!";
                return null;
            }

            var isStockNumeric = int.TryParse(AlbStock, out int stock);
            if (!isStockNumeric)
            {
                view.ErrorMessage = "Album stock must be numeric";
                return null;
            }
            if (stock <= 0)
            {
                view.ErrorMessage = "Album stock must be more than 0";
                return null;
            }

            if (upImage.PostedFile.FileName.Equals(""))
            {
                view.ErrorMessage = "Please choose Album Image!";
                return null;
            }

            else if (upImage.PostedFile.ContentLength >= 2000000)
            {
                view.ErrorMessage = "Image file size must be lower than 2MB";
                return null;
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
                    return null;
                }
            }

            return handler.updateAlbum(AlbumID, AlbName, AlbDesc, price, stock, upImage);
        }


        public List<Album> GetAllAlbumsByArtistID(int id)
        {
            return handler.GetAlbumsByArtistID(id);
        }

        public Album GetAlbumByAlbumID(int id)
        {
            return handler.GetAlbumByAlbumID(id);
        }

        public Album DeleteAlbum(int id)
        {
            return handler.deleteAlbum(id);
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
