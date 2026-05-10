using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFRally.Infrastructure;

namespace WPFRally
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SpriteAtlas Atlas { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Atlas = new SpriteAtlas("Assets/Sprites/spritesheet_tiles.png", "Assets/Sprites/spritesheet_tiles.xml");
            SpriteManager.LoadAll(); // если ещё нужен старый менеджер
        }
    }
}
