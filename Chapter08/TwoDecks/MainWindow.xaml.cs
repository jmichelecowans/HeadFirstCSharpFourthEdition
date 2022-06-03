using System.Windows;
using System.Windows.Input;

namespace TwoDecks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (Resources["rightDeck"] is Deck rightDeck)
            {
                rightDeck.Clear();
            }
        }

        private void MoveCard(bool leftToRight)
        {
            if ((Resources["rightDeck"] is Deck rightDeck) && (Resources["leftDeck"] is Deck leftDeck))
            {
                if (leftToRight)
                {
                    if (leftDeckListBox.SelectedItem is Card card)
                    {
                        leftDeck.Remove(card);
                        rightDeck.Add(card);
                    }
                }
                else
                {
                    if (rightDeckListBox.SelectedItem is Card card)
                    {
                        rightDeck.Remove(card);
                        leftDeck.Add(card);
                    }
                }
            }
        }

        private void ShuffleLeftDeck_Click(object sender, RoutedEventArgs e)
        {
            if (Resources["leftDeck"] is Deck leftDeck)
            {
                leftDeck.Shuffle();
            }
        }

        private void ClearRightDeck_Click(object sender, RoutedEventArgs e)
        {
            if (Resources["rightDeck"] is Deck rightDeck)
            {
                rightDeck.Clear();
            }
        }

        private void ResetLeftDeck_Click(object sender, RoutedEventArgs e)
        {
            if (Resources["leftDeck"] is Deck leftDeck)
            {
                leftDeck.Reset();
            }
        }

        private void SortRightDeck_Click(object sender, RoutedEventArgs e)
        {
            if (Resources["rightDeck"] is Deck rightDeck)
            {
                rightDeck.Sort();
            }
        }

        private void LeftDeckListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MoveCard(true);
        }

        private void RightDeckListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MoveCard(false);
        }

        private void LeftDeckListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MoveCard(true);
            }
        }

        private void RightDeckListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MoveCard(false);
            }
        }
    }
}
