using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBlog.Application.Statics
{
    public static class PathTools
    {
        public static readonly string UploadEditorServerPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/content/editor/");
        public static readonly string UploadEditorPath = "/content/editor/";
        public static readonly string PostImageSreverPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/post-image/");
        public static readonly string PostImagePath = "/content/post-image/";
        public static readonly string UserAvatrPath = "/content/user/";
        public static readonly string CategoryImageServerPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/category-image/");
        public static readonly string CategoryImagePath = "/content/category-image/";

    }
}
