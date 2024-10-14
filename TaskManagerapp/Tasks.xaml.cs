using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using TaskManagerapp;

namespace TaskManagerapp
{
    public partial class Tasks : ContentPage
    {
        // List of tasks
        private List<string> tasks;

        public Tasks()
        {
            InitializeComponent();
            infographicCarouselView.ItemsSource = new List<string>
{

    "taskkkkkkk3.png",
    "taskkkkk1.png",
    "taskkkk2.png"
};

            // Initialize with sample tasks
            tasks = new List<string>
            {
                "Task 1",
                "Task 2",
                "Task 3",
                "Task 4",
                "Task 5",
                "Task 6"
            };

            // Set the list of tasks to the CollectionView's ItemsSource
            tasksCollectionView.ItemsSource = tasks;
        }

        // Event handler for tapping on a task to navigate to its detail page
        private async void OnTaskTapped(object sender, EventArgs e)
        {
            var label = sender as Label;
            string task = label?.BindingContext as string;

            if (task != null)
            {
                // Navigate to the TaskDetailPage and pass the task name as a parameter
                await Navigation.PushAsync(new TaskDetailPage(task));
            }
        }

        // Event handler for swipe-to-delete action
        private void OnDeleteTask(object sender, EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            string taskToDelete = swipeItem?.CommandParameter as string;

            if (taskToDelete != null)
            {
                // Remove the task from the list
                tasks.Remove(taskToDelete);

                // Refresh the CollectionView to update the UI
                tasksCollectionView.ItemsSource = null;
                tasksCollectionView.ItemsSource = tasks;
            }
        }
    }

    internal class infographicCarouselView
    {
        public static List<string> ItemsSource { get; internal set; }
    }

    internal class tasksCollectionView
    {
        public static List<string> ItemsSource { get; internal set; }
    }
}
