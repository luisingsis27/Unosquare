using CoreGraphics;
using Foundation;
using InfColorPicker;
using System;
using UIKit;

namespace BindingPruebaLuis
{
    public partial class ViewController : UIViewController
    {

        ColorSelectedDelegate selector;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.


            btnCambiarColor.ClipsToBounds = true;
            btnCambiarColor.Layer.CornerRadius = btnCambiarColor.Frame.Height / 2;
            btnCambiarColor.SetTitleColor(UIColor.White, UIControlState.Normal);
            btnCambiarColor.Layer.ShadowColor = UIColor.Black.CGColor;
            btnCambiarColor.Layer.ShadowRadius = 2.0f;
            btnCambiarColor.Layer.ShadowOffset = new CGSize(2.0, 2.0);
            btnCambiarColor.Layer.MasksToBounds = false;
            btnCambiarColor.Layer.ShadowOpacity = 0.8f;
            btnCambiarColor.Layer.BorderColor = UIColor.DarkGray.CGColor;
            btnCambiarColor.Layer.BorderWidth = 3.0f;
            //btnCambiarColor.TouchUpInside += BtnCambiarColor_TouchUpInside;
            btnCambiarColor.TouchUpInside += HandleTouchUpInsideWithStrongDelegate;
            selector = new ColorSelectedDelegate(this);
        }

        private void HandleTouchUpInsideWithStrongDelegate(object sender, EventArgs e)
        {
            InfColorPickerController picker = InfColorPickerController.ColorPickerViewController;
            picker.Delegate = selector;
            picker.PresentModallyOverViewController(this);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }


    public class ColorSelectedDelegate : InfColorPickerControllerDelegate
    {
        readonly UIViewController parent;

        public ColorSelectedDelegate(UIViewController parent)
        {
            this.parent = parent;
        }

        public override void ColorPickerControllerDidFinish(InfColorPickerController controller)
        {
            parent.View.BackgroundColor = controller.ResultColor;
            parent.DismissViewController(false, null);
        }
    }
}