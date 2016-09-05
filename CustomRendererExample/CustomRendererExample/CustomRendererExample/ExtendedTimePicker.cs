using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace CustomRendererExample
{
    /// <summary>
    /// This custom renderer exists to give Android dynamic 12h/24h switching TimePicker capabilities.
    /// The Xamarin IOS TimePicker switches flawlessly between 12h and 24h with current Xamarin version targeting
    /// IOS 9.21 (tested 2016-05-11), and is therefore not warranted
    /// </summary>
    public class ExtendedTimePicker : TimePicker
    {
    }
}