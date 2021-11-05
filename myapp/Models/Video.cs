using System;
using Xamarin.Forms;

namespace myapp.Models
{
    public class Video
    {
        
        string _name;
        public string Name { get => _name; set => _name = value; }

        string _file;
        public string File { get => _file; set => _file = value; }

        ImageSource _preview;
        public ImageSource Preview { get => _preview; set => _preview = value; }
        
    }
}