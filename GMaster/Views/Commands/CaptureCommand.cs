using System;
using System.Threading.Tasks;

namespace GMaster.Views.Commands
{
    public class CaptureCommand : AbstractModelCommand<CameraViewModel>
    {
        public CaptureCommand(CameraViewModel model)
            : base(model)
        {
        }

        protected override bool InternalCanExecute() => Model.SelectedCamera != null;

        protected override async Task InternalExecute()
        {
            var lumix = Model.SelectedCamera;
            if (lumix == null)
            {
                return;
            }

            try
            {
                await lumix.Camera.Capture();
            }
            catch (Exception)
            {
            }
        }
    }
}