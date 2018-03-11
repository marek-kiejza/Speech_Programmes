using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Speech.Synthesis;
using System.Threading;




namespace WpfApplication11
{
    /// <summary>
    /// Interaction logic for LearningToWrite.xaml
    /// </summary>
    public partial class LearningToWrite : Window
    {
        // SpeechSynthesizer s = new SpeechSynthesizer();
        SpeechSynthesizer speach = new SpeechSynthesizer();
        Random random = new Random();
         int num;
         public string[] preposition = { "about", "above", "according", "across", "after", "against", "along", "along with", "among", "apart from", "around", "as for", "because of", "before", "behind", "below", "beneath", "beside", "between", "beyond", "but", "by", "means", "concerning ", "despite", "down", "during", "except", "except for", "excepting", "for", "from", "addition to", "back of", "in case of", "front of", "place", "inside", "spite of", "instead", "into", "like", "near", "next", "onto", "on top of", "outside", "over", "past", "regarding", "round", "since", "through", "throughout", "till", "toward", "under", "underneath", "unlike", "until", "upon", "up to", "with", "within", "without" };
         Thread th;
         int ctr = 0;  int points = 0, totalPoints = 0, round = 0;

        public LearningToWrite(string[] words)
        {
            InitializeComponent();
            Random random = new Random();
            

            speach.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen);
            speach.Rate = 0;

            int randomNumber = random.Next(0, preposition.Length - 1);
            num = randomNumber;
          
         //   preposition = words;

        }
        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {


        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
           
            speach.Rate = -6;
           speach.Speak(preposition[num]);
            

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_Corect_Click(object sender, RoutedEventArgs e)
        {
            speach.Rate = 0;
            if (textBox.Text.ToString() == preposition[num])
            {

                speach.Speak("correct");

                round++;
                textBox.Clear();

                for (int i = 0; i < preposition[num].Length; i++)
                {
                    points++;
                }
                totalPoints += (points - ctr);
                label.Content = totalPoints.ToString();
                points = 0;
                ctr = 0;
                num = random.Next(0, preposition.Length - 1);
             /*   if (round == 2)
                {

                    this.Close();
                    th = new Thread(openForm2);

                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }*/

            }
            else
            {
                textBox.Clear();
                speach.Speak("wrong answer");


                var chars = preposition[num].ToCharArray();


                for (int cou = 0; cou <= ctr; cou++)
                {

                    textBox.Text += chars[cou].ToString();


                }

                if (ctr >= chars.Length)
                    ctr = chars.Length;
                else
                    ctr++;


            }
        }
    }
}

