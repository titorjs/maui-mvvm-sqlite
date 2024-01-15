using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductoMVVMSQLite.Models;

namespace ProductoMVVMSQLite.Utils
{
    public static class Util
    {

        private static List<Producto> _listaProductos;

        public static List<Producto> ListaProductos
        {
            get { return _listaProductos; }
            set
            {
                _listaProductos = value;
                OnListaProductosChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        public static event EventHandler OnListaProductosChanged;

        private const string DBFileName = "producto.db3";
        public const SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        public static string DataBasePath
        {
            get
            {
                return Path.Combine(FileSystem.AppDataDirectory, DBFileName);
            }
        }
    }
}
