using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Timers;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using Sandbox.MVVMCross.TestNavigation.Core.ViewModels;
using UIKit;
using Xamarin.iOS.iCarouselBinding;


namespace Sandbox_MVVMCross_TestNavigation.iOS.Views.MyMenuView
{
    [MvxFromStoryboard("MyMenuView")]
    [MvxTabPresentation(WrapInNavigationController = false, TabIconName = "icnmymenu", TabName = "My Menu")]
    public partial class MyMenuView : MvxViewController<MyMenuViewModel>
    {
        public MyMenuView(IntPtr handle) : base(handle)
        {
        }

        private List<int> items;
        iCarousel carousel;
        int posicao = 0;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            items = Enumerable.Range(1, 3).ToList();

            // Setup iCarousel view
            carousel = new iCarousel
            {
                Bounds = carrosselView.Frame,
                ContentMode = UIViewContentMode.Center,
                Type = iCarouselType.Rotary,
                Frame = carrosselView.Bounds,
                CenterItemWhenSelected = true,
                DataSource = new SimpleDataSource(items),
                Delegate = new SimpleDelegate(this)
            };

            //carousel.CurrentItemIndex = 2;


            carrosselView.AddSubview(carousel);
            //carousel.Frame = carrosselView.Bounds;
            carousel.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
            //ViewDidLayoutSubviews();

            System.Timers.Timer timer = new System.Timers.Timer(3000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            posicao = posicao > 2 ? 0 : posicao + 1;
            carousel.ScrollToItemAtIndex(posicao, true);
        }

        partial void UIButton896_TouchUpInside(UIButton sender)
        {
            posicao = posicao > 2 ? 0 : posicao + 1;
            carousel.ScrollToItemAtIndex(posicao, true);
        }

        public class SimpleDataSource : iCarouselDataSource
        {
            private readonly List<int> _data;

            public SimpleDataSource(List<int> data)
            {
                _data = data;
            }

            public override nint NumberOfItemsInCarousel(iCarousel carousel) => _data.Count;

            public override UIView ViewForItemAtIndex(iCarousel carousel, nint index, UIView view)
            {
                UILabel label;

                // create new view if no view is available for recycling
                if (view == null)
                {
                    var imgView = new UIImageView(new Rectangle(0, 0, Convert.ToInt32(carousel.Frame.Width), Convert.ToInt32(carousel.Frame.Height)))
                    {
                        BackgroundColor = UIColor.Orange,
                        ContentMode = UIViewContentMode.Center
                    };

                    label = new UILabel(imgView.Bounds)
                    {
                        BackgroundColor = UIColor.Clear,
                        TextAlignment = UITextAlignment.Center,
                        Tag = 1
                    };
                    imgView.AddSubview(label);
                    view = imgView;
                }
                else
                {
                    // get a reference to the label in the recycled view
                    label = (UILabel)view.ViewWithTag(1);
                }

                label.Text = _data[(int)index].ToString();

                return view;
            }
        }

        public class SimpleDelegate : iCarouselDelegate
        {
            private readonly MyMenuView _viewController;

            public SimpleDelegate(MyMenuView vc)
            {
                _viewController = vc;
            }

            public override void DidSelectItemAtIndex(iCarousel carousel, nint index)
            {
                var alert = UIAlertController.Create("Clicked index:", index.ToString(), UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));

                _viewController.PresentViewController(alert, animated: true, completionHandler: null);
            }
        }
    }
}

