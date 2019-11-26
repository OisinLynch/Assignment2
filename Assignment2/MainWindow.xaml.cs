using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Assignment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Activity> activities = new List<Activity>();
        List<Activity> selectedActivities = new List<Activity>();
        List<Activity> filteredActivities = new List<Activity>();

        decimal totalCost = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //Creating the activity objects
            Activity l1 = new Activity()
            {
                Name = "Treking",
                Description = "Instructor led group trek through local mountains. Cost - 20",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Land,
                Cost = 20m
            };

            Activity l2 = new Activity()
            {
                Name = "Mountain Biking",
                Description = "Instructor led half day mountain biking.  All equipment provided. Cost - 30",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Land,
                Cost = 30m
            };

            Activity l3 = new Activity()
            {
                Name = "Abseiling",
                Description = "Experience the rush of adrenaline as you descend cliff faces from 10-500m. Cost - 40",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Land,
                Cost = 40m
            };

            Activity w1 = new Activity()
            {
                Name = "Kayaking",
                Description = "Half day lakeland kayak with island picnic. Cost - 40",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Water,
                Cost = 40m
            };

            Activity w2 = new Activity()
            {
                Name = "Surfing",
                Description = "2 hour surf lesson on the wild atlantic way. Cost - 25",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Water,
                Cost = 25m
            };

            Activity w3 = new Activity()
            {
                Name = "Sailing",
                Description = "Full day lakeland kayak with island picnic. Cost - 50",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Water,
                Cost = 50m
            };

            Activity a1 = new Activity()
            {
                Name = "Parachuting",
                Description = "Experience the thrill of free fall while you tandem jump from an airplane. Cost - 100",
                ActivityDate = new DateTime(2019, 06, 01),
                TypeOfActivity = ActivityType.Air,
                Cost = 100m
            };

            Activity a2 = new Activity()
            {
                Name = "Hang Gliding",
                Description = "Soar on hot air currents and enjoy spectacular views of the coastal region. Cost - 80",
                ActivityDate = new DateTime(2019, 06, 02),
                TypeOfActivity = ActivityType.Air,
                Cost = 80m
            };

            Activity a3 = new Activity()
            {
                Name = "Helicopter Tour",
                Description = "Experience the ultimate in aerial sight-seeing as you tour the area in our modern helicopters. Cost - 200",
                ActivityDate = new DateTime(2019, 06, 03),
                TypeOfActivity = ActivityType.Air,
                Cost = 200m
            };

            //Adding activities to the list
            activities.Add(l1);
            activities.Add(l2);
            activities.Add(l3);
            activities.Add(w1);
            activities.Add(w2);
            activities.Add(w3);
            activities.Add(a1);
            activities.Add(a2);
            activities.Add(a3);

            //Sort by date
            activities.Sort();

            //Display the activities in the listbox
            lbxActivitySelect.ItemsSource = null;
            lbxActivitySelect.ItemsSource = activities;

            //Add activity description to description text block when selected
           

        }//end of window loaded

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Find what item is selected 
            Activity selectedActivity = lbxActivitySelect.SelectedItem as Activity;


            //Null check
            if (selectedActivity != null)
            {
                //Move activity from ActivitySelect box to SelectedActivity box
                activities.Remove(selectedActivity);
                selectedActivities.Add(selectedActivity);

                //Update total
                totalCost += selectedActivity.Cost;
                tblkTotalCost.Text = totalCost.ToString();

                //Sort the seleced activities by date
                selectedActivities.Sort();

                //Refreash screen
                lbxActivitySelect.ItemsSource = null;
                lbxActivitySelect.ItemsSource = activities;

                lbxSelectedActivities.ItemsSource = null;
                lbxSelectedActivities.ItemsSource = selectedActivities;
            }

            //Message box to alert user that no activity has been slected to add
            else if (selectedActivity == null)
            {
                MessageBox.Show("No activity has been selected to add");
            }

            else if (selectedActivity.ActivityDate == selectedActivity.ActivityDate)
            {
                MessageBox.Show("These dates conflict");
            }

        }//End of add button click

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            //Find what item is selected 
            Activity selectedActivity = lbxSelectedActivities.SelectedItem as Activity;


            //Null check
            if (selectedActivity != null)
            {
                //Move activity from ActivitySelect box to SelectedActivity box
                activities.Add(selectedActivity);
                selectedActivities.Remove(selectedActivity);

                //Update total
                totalCost -= selectedActivity.Cost;
                tblkTotalCost.Text = totalCost.ToString();

                //Refreash screen
                lbxActivitySelect.ItemsSource = null;
                lbxActivitySelect.ItemsSource = activities;

                lbxSelectedActivities.ItemsSource = null;
                lbxSelectedActivities.ItemsSource = selectedActivities;
            }

            //Message box to alert user that no activity has been selected to remove
            else if (selectedActivity == null)
            {
                MessageBox.Show("No activity has been selected to remove");
            }

        }//End of remove button click

        //Refreash screen method
        private void RefreashScreen()
        {
            lbxActivitySelect.ItemsSource = null;
            lbxActivitySelect.ItemsSource = activities;

            lbxSelectedActivities.ItemsSource = null;
            lbxSelectedActivities.ItemsSource = selectedActivities;
        }//End of refreash screen

        //Deals with all raio button filters
        private void RadioAll_Click(object sender, RoutedEventArgs e)
        {
            filteredActivities.Clear();

            if (radioAll.IsChecked == true)
            {
                //Sow all activities
                RefreashScreen();
            }
            else if (radioLand.IsChecked == true)
            {
                //Show only land activities
                foreach (Activity activity in activities)
                {
                    if (activity.TypeOfActivity == ActivityType.Land)
                    {
                        filteredActivities.Add(activity);
                        lbxActivitySelect.ItemsSource = null;
                        lbxActivitySelect.ItemsSource = filteredActivities;
                    }
                }
            }
            else if (radioWater.IsChecked == true)
            {
                //Show only water activities
                foreach (Activity activity in activities)
                {
                    if (activity.TypeOfActivity == ActivityType.Water)
                    {
                        filteredActivities.Add(activity);
                        lbxActivitySelect.ItemsSource = null;
                        lbxActivitySelect.ItemsSource = filteredActivities;
                    }
                }
            }
            else if (radioAir.IsChecked == true)
            {
                //Show only air activities
                foreach (Activity activity in activities)
                {
                    if (activity.TypeOfActivity == ActivityType.Air)
                    {
                        filteredActivities.Add(activity);
                        lbxActivitySelect.ItemsSource = null;
                        lbxActivitySelect.ItemsSource = filteredActivities;
                    }
                }
            }

        }//End of radio button all click 

        //Show description when activity has been selected
        private void LbxActivitySelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Find what item is selected 
            Activity selectedActivity = lbxActivitySelect.SelectedItem as Activity;


            //Null check
            if (selectedActivity != null)
            {
                tblxDescription.Text = selectedActivity.Description;
            }

        }
    }//end main
}
