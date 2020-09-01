using System;

namespace Toolkit.UI.WPF.Controls
{
    [Flags]
    public enum DialogBoxButtons
    {
        Primary         = 1 << 0,
        Secondary       = 1 << 1,
        Close           = 1 << 2,
        PrimaryAndClose = Primary | Close,
        All             = PrimaryAndClose | Secondary
    }
}