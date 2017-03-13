using System;
namespace UI.Web
{
    public interface IWebControlBase
    {
        void AddException(Exception exception);
        void CallTryMethod(UI.Web.TryMethodDelegate method);
        string CommandName { get; set; }
        string CommandValue { get; set; }
        event ControlCommandHandler ControlCommand;
        object GetParameter(string parameter);
        T GetParameter<T>(string parameter) where T : class;
        T GetViewState<T>(string key) where T : class;
        object GetViewState(string key);
        void RaiseControlCommand(string commandName);
        void RaiseControlCommand(string commandName, object value);
        void SetParameter(string parameter, object value);
        void SetViewState(string key, object value);
    }
}
