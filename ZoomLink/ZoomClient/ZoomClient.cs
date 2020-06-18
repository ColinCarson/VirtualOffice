namespace ZoomClient
{
    using System;
    using System.Threading;
    using ZOOM_SDK_DOTNET_WRAP;

    public class ZoomClient
    {
        private const string appKey = "gMmfDYCtl5Q5XuW0LDRmVwvBZ2hkrL5sZSIw";
        private const string appSecret = "znG1DyfksA9IcBU9bQ7JNq3l1oTMfQbnYa1Q";

        private string userName;
        private string meetingId;
        private string meetingPassword;

        public void JoinMeeting(string userName, string meetingId, string meetingPassword)
        {
            //RegisterCallbacks();

            this.userName = userName;
            this.meetingId = meetingId;
            this.meetingPassword = meetingPassword;

            //Login();
        }

        public void DoNothing()
        {

        }

        private void RegisterCallbacks()
        {
            ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetAuthServiceWrap().Add_CB_onAuthenticationReturn(onAuthenticationReturn);
            ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().Add_CB_onMeetingStatusChanged(onMeetingStatusChanged);
            ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().
                GetMeetingParticipantsController().Add_CB_onHostChangeNotification(onHostChangeNotification);
            ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().
                GetMeetingParticipantsController().Add_CB_onLowOrRaiseHandStatusChanged(onLowOrRaiseHandStatusChanged);
            ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().
                GetMeetingParticipantsController().Add_CB_onUserJoin(onUserJoin);
            ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().
                GetMeetingParticipantsController().Add_CB_onUserLeft(onUserLeft);
            ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().
                GetMeetingParticipantsController().Add_CB_onUserNameChanged(onUserNameChanged);
        }

        private void Login()
        {
            ZOOM_SDK_DOTNET_WRAP.AuthParam param = new ZOOM_SDK_DOTNET_WRAP.AuthParam();

            param.appKey = appKey;
            param.appSecret = appSecret;

            Console.WriteLine("     Issuing Login Request...");
            ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetAuthServiceWrap().SDKAuth(param);

            Thread.Sleep(5000);

            Console.WriteLine("     Joining Meeting...");
            ZOOM_SDK_DOTNET_WRAP.JoinParam joinParam = new ZOOM_SDK_DOTNET_WRAP.JoinParam();
            joinParam.userType = ZOOM_SDK_DOTNET_WRAP.SDKUserType.SDK_UT_APIUSER;
            ZOOM_SDK_DOTNET_WRAP.JoinParam4APIUser join_api_param = new ZOOM_SDK_DOTNET_WRAP.JoinParam4APIUser();
            join_api_param.meetingNumber = UInt64.Parse(meetingId);
            join_api_param.userName = userName;
            joinParam.apiuserJoin = join_api_param;

            ZOOM_SDK_DOTNET_WRAP.SDKError err = ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().Join(joinParam);
            if (err == SDKError.SDKERR_UNINITIALIZE)
                throw new Exception("Unable to initialize SDK");

            Thread.Sleep(5000);
        }

        private void JoinMeetingInternal(string meetingId, string meetingPassword)
        {
            Console.WriteLine("     Joining Meeting...");
            ZOOM_SDK_DOTNET_WRAP.JoinParam param = new ZOOM_SDK_DOTNET_WRAP.JoinParam();
            param.userType = ZOOM_SDK_DOTNET_WRAP.SDKUserType.SDK_UT_APIUSER;
            ZOOM_SDK_DOTNET_WRAP.JoinParam4APIUser join_api_param = new ZOOM_SDK_DOTNET_WRAP.JoinParam4APIUser();
            join_api_param.meetingNumber = UInt64.Parse(meetingId);
            join_api_param.userName = userName;
            param.apiuserJoin = join_api_param;

            ZOOM_SDK_DOTNET_WRAP.SDKError err = ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().Join(param);
            if (ZOOM_SDK_DOTNET_WRAP.SDKError.SDKERR_SUCCESS == err)
            {
                throw new Exception($"Unable to join meeting {meetingId} : {err}");
            }
        }

        public void onAuthenticationReturn(AuthResult ret)
        {
            Console.WriteLine("     Processing Login Callback...");
            if (ZOOM_SDK_DOTNET_WRAP.AuthResult.AUTHRET_SUCCESS == ret)
            {
                JoinMeetingInternal(meetingId, meetingPassword);
            }
            else
            {
                throw new Exception($"Unable to login to Zoom API: {ret}");
            }
        }

        public void onMeetingStatusChanged(MeetingStatus status, int iResult)
        {
            switch (status)
            {
                case ZOOM_SDK_DOTNET_WRAP.MeetingStatus.MEETING_STATUS_ENDED:
                case ZOOM_SDK_DOTNET_WRAP.MeetingStatus.MEETING_STATUS_FAILED:
                    {
                        Console.WriteLine($"Meeting Status {status}");
                    }
                    break;
                default://todo
                    break;
            }
        }

        public void onUserJoin(Array lstUserID)
        {
            if (null == (Object)lstUserID)
                return;

            for (int i = lstUserID.GetLowerBound(0); i <= lstUserID.GetUpperBound(0); i++)
            {
                UInt32 userid = (UInt32)lstUserID.GetValue(i);
                ZOOM_SDK_DOTNET_WRAP.IUserInfoDotNetWrap user = ZOOM_SDK_DOTNET_WRAP.CZoomSDKeDotNetWrap.Instance.GetMeetingServiceWrap().
                    GetMeetingParticipantsController().GetUserByUserID(userid);
                if (null != (Object)user)
                {
                    string name = user.GetUserNameW();
                    Console.Write(name);
                }
            }
        }
        public void onUserLeft(Array lstUserID)
        {
            //todo
        }
        public void onHostChangeNotification(UInt32 userId)
        {
            //todo
        }
        public void onLowOrRaiseHandStatusChanged(bool bLow, UInt32 userid)
        {
            //todo
        }
        public void onUserNameChanged(UInt32 userId, string userName)
        {

        }
    }
}
