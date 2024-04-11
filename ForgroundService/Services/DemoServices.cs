#if ANDROID

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgroundService.Services
{
    [Service]
    public class DemoServices : Service, IServiceTest
    {
        Timer timer;

        public override IBinder? OnBind(Intent? intent)
        {
            return null;
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent? intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {

            timer = new Timer(InvokeNotification,null,0,1000);
          

            if (intent.Action == "START_SERVICE")
            {
                RegisterNotification();
            }
            else if(intent.Action == "STOP_SERVICE")
            {
                StopForeground(true);
                StopSelfResult(startId);
            }

            //sticky means that when there is enough memory 
            //the Android OS will restart this activity 
            return StartCommandResult.Sticky;
        }



        public void StartService()
        {
            Intent startService = new Intent(MainActivity.activityCurrent, typeof(DemoServices));
            startService.SetAction("START_SERVICE");
            MainActivity.activityCurrent.StartService(startService);
        }

        public void StopService()
        {
            Intent stopIntent = new Intent(MainActivity.activityCurrent, this.Class);
            stopIntent.SetAction("STOP_SERVICE");
            MainActivity.activityCurrent.StopService(stopIntent);
        }

        private void RegisterNotification()
        {
            NotificationChannel channel = new NotificationChannel("ServiceChannel", "ServiceDemo", NotificationImportance.Max);
            NotificationManager manager = (NotificationManager)MainActivity.activityCurrent.GetSystemService(Context.NotificationService);
            manager.CreateNotificationChannel(channel);
            Notification notification = new Notification.Builder(this, "ServiceChannel")
               .SetContentTitle("Service Working")
               .SetContentText("Some Testing Being Done")
               .SetSmallIcon(Resource.Drawable.test_level_drawable)
               .SetOngoing(true)
               .Build();

            StartForeground(100, notification);
        }

        public void InvokeNotification(object sender)
        {
            RegisterNotification();
        }
    }
}

#endif
