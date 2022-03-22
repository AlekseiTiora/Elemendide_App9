using System;
using System.Collections.Generic;
using System.Text;

namespace Elemendide_App
{
    public interface IAudio
    {
        void PlayAudioFile(string fileName);
        void Stop(string fileName);

    }
}
