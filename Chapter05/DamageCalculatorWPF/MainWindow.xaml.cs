using System;
using System.Windows;

namespace DamageCalculatorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Random random = new Random();
        private readonly SwordDamage swordDamage;

        public MainWindow()
        {
            InitializeComponent();
            swordDamage = new SwordDamage(random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7));
            DisplayDamage();
        }

        private void RollDice()
        {
            swordDamage.Roll = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
            DisplayDamage();
        }

        private void DisplayDamage()
        {
            swordDamage.Flaming = flaming.IsChecked.Value;
            swordDamage.Magic = magic.IsChecked.Value;
            damage.Text = $"Rolled {swordDamage.Roll} for {swordDamage.Damage} HP";
        }

        private void CheckedChanged(object sender, RoutedEventArgs e)
        {
            DisplayDamage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RollDice();
        }
    }
}
