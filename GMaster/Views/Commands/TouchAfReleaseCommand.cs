namespace GMaster.Views.Commands
{
    using System;
    using System.Threading.Tasks;
    using Core.Camera.LumixData;
    using Core.Tools;
    using Models;
    using Tools;

    public class TouchAfReleaseCommand : AbstractModelCommand<CameraViewModel>
    {
        protected override bool InternalCanExecute() => true;

        protected override async Task InternalExecute()
        {
            var lumix = Model.SelectedCamera;
            if (lumix == null)
            {
                return;
            }

            try
            {
                if (lumix.Camera.LumixState.FocusMode != FocusMode.MF)
                {
                    await lumix.Camera.ReleaseTouchAF();
                }
                else
                {
                    await lumix.Camera.MfAssistOff();
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}