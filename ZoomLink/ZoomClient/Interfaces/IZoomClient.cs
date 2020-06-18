using System;
using System.Collections.Generic;
namespace ZoomClient.Interfaces
{
    interface IZoomClient
    {
        void JoinMeeting(string userName, string meetingId, string meetingPassword);
    }
}
