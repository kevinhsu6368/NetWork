using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServer
{
    public enum ROUND_IN_TYPE
    {
        a,
        b,
        c
    }

    public enum ROUND_OUT_TYPE
    {
        a,
        b,
        c
    }

    public enum BULL
    {
        a,
        b,
        c
    }

    public interface IBullHunterPlayer
    {
        Guid Id { get; }
        int Score { get; }
        bool FinishGame { get; }

        ROUND_IN_TYPE InType { get; }
        ROUND_OUT_TYPE OutType { get; }

        BULL BullType { get; }

        event Action<int> ScoreEvent;
    }
}
