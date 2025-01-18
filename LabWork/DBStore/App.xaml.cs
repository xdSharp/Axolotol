using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DBStore.Models
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LibraryContext>());
    }
}
