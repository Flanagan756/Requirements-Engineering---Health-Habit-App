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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Heathy_Habit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Varibles
        int counter = 0;
        int achieved = 0;
        int failed = 0;

        //Lists
        List<Goals> allSetGoals = new List<Goals>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Goals g1 = new Goals()
            {
                GoalName = txtbxSetGoalName.Text,
                GoalDescription = txtbxSetGoalDescription.Text

            };
        
        }
        private void btnCreateGoal_Click(object sender, RoutedEventArgs e)
        {
            int goalNum = 0;
            if (goalNum == 0)
            {

                Goals g1 = new Goals()
                {
                    GoalName = txtbxSetGoalName.Text,
                    GoalDescription = txtbxSetGoalDescription.Text

                };

                //add to list
                allSetGoals.Add(g1);
                RefreshScreen();
            }
          
            goalNum++;
            

            lbxGoalsInProgress.ItemsSource = allSetGoals;

        }

        private void btnAddPoint_Click(object sender, RoutedEventArgs e)
        {
            
            //What item is selected
            Goals selectedGoal = lbxGoalsInProgress.SelectedItem as Goals;

            //null check
            if (selectedGoal != null)
            {
                //Add to counter
                counter++;

                if (counter == 5)
                {
                    MessageBox.Show("Congratulation on achiveing your goal", "Healthy Habits App", MessageBoxButton.OK, MessageBoxImage.Information);

                    //Removes the selected goal from the list
                    allSetGoals.Remove(selectedGoal);

                    achieved++;
                    txtbxAchieved.Text = achieved.ToString();
                    counter = 0;
                    RefreshScreen();

                }
                
            }


        }
        private void btnMinusPoint_Click(object sender, RoutedEventArgs e)
        {
        
            //What item is selected
            Goals selectedGoal = lbxGoalsInProgress.SelectedItem as Goals;
      
            //null check
            if (selectedGoal != null)
            {
              
                //Add to counter
                counter--;

                if (counter == -5)
                {
                    MessageBox.Show("You failed your goal...Try harder next time!", "Healthy Habits App", MessageBoxButton.OK, MessageBoxImage.Warning);

                    //Removes the selected goal from the list
                    allSetGoals.Remove(selectedGoal);

                  
                    counter = 0;
                    failed++;
                    txtbxFailed.Text = failed.ToString();
                    RefreshScreen();

                }

            }

        }

        private void btnDeleteGoal_Click(object sender, RoutedEventArgs e)
        {
            Goals selectedGoal = lbxGoalsInProgress.SelectedItem as Goals;
            if (selectedGoal != null)
            {

                //Removes the selected goal from the list
                allSetGoals.Remove(selectedGoal);

                RefreshScreen();
            }

        }
        private void RefreshScreen()
        {
            //Refresh Screen
            lbxGoalsInProgress.ItemsSource = null;
            lbxGoalsInProgress.ItemsSource = allSetGoals;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Goals selectedGoal = lbxGoalsInProgress.SelectedItem as Goals;

            selectedGoal.GoalName = txtbxSetGoalName.Text;
            selectedGoal.GoalDescription = txtbxSetGoalDescription.Text;

            RefreshScreen();
        }

      
    }
}
