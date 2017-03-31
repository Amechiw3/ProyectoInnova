using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ProyectoInnovaDESK.Tools
{
    class ImagenTool
    {
        public static Bitmap Base64StringToBitmap(string base64String)
        {
            Bitmap bmpReturn = null;

            byte[] byteBuffer = Convert.FromBase64String(base64String);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);

            memoryStream.Position = 0;

            bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);

            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;

            return bmpReturn;
        }

        public static string ToBase64String(Bitmap bmp, ImageFormat imageFormat)
        {
            string base64String = string.Empty;

            MemoryStream memoryStream = new MemoryStream();
            bmp.Save(memoryStream, imageFormat);

            memoryStream.Position = 0;
            byte[] byteBuffer = memoryStream.ToArray();

            memoryStream.Close();

            base64String = Convert.ToBase64String(byteBuffer);
            byteBuffer = null;

            return base64String;
        }

        /// <summary>
        /// FUNCION QUE CARGA LA IMAGEN LOCAL (DEFAULT) LA COMBIERTE A BITMAP Y LA COMBIERTE A TEXTO         
        /// 
        /// IP CAMARA:
        /// http://www.camera-sdk.com/p_53-how-to-take-a-picture-snapshot-and-save-it-as-jpg-in-c-onvif.html
        /// </summary>
        /// <param name="imgDEfault">Nombre de la Imagen a Cargar</param>
        /// <returns>texto base 64 de la imagen</returns>
        public static string CargarImagenDefault(String imgDEfault = "coche_silueta.jpg")
        {
            string txtImagen = "";
            String path = Path.Combine(Application.StartupPath, String.Format("Comun\\{0}", imgDEfault));
            if (File.Exists(path))
            {
                Bitmap imagen = new System.Drawing.Bitmap(path);
                txtImagen = ToBase64String(imagen, ImageFormat.Jpeg);
            }

            return txtImagen;
        }
    }
}
