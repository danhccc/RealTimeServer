using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class NetworkedServerProcessing
{

    #region Send and Receive Data Functions
    static public void ReceivedMessageFromClient(string msg, int clientConnectionID)
    {
        Debug.Log("msg received = " + msg + ".  connection id = " + clientConnectionID);

        string[] csv = msg.Split(',');
        int signifier = int.Parse(csv[0]);

        if (signifier == ClientToServerSignifiers.KeyboardInputUpdate)
        {
            int direction = int.Parse(csv[1]);

            gameLogic.UpdateDirectionalInput(direction);
        }
        // else if (signifier == ClientToServerSignifiers.asd)
        // {

        // }

        //gameLogic.DoSomething();
    }
    static public void SendMessageToClient(string msg, int clientConnectionID)
    {
        networkedServer.SendMessageToClient(msg, clientConnectionID);
    }

    #endregion

    #region Connection Events

    static public void ConnectionEvent(int clientConnectionID)
    {
        Debug.Log("New Connection, ID == " + clientConnectionID);
    }
    static public void DisconnectionEvent(int clientConnectionID)
    {
        Debug.Log("New Disconnection, ID == " + clientConnectionID);
    }

    #endregion

    #region Setup
    static NetworkedServer networkedServer;
    static GameLogic gameLogic;

    static public void SetNetworkedServer(NetworkedServer NetworkedServer)
    {
        networkedServer = NetworkedServer;
    }
    static public NetworkedServer GetNetworkedServer()
    {
        return networkedServer;
    }
    static public void SetGameLogic(GameLogic GameLogic)
    {
        gameLogic = GameLogic;
    }

    #endregion
}

#region Protocol Signifiers
static public class ClientToServerSignifiers
{
    //public const int asd = 1;
    public const int KeyboardInputUpdate = 1;
}

static public class ServerToClientSignifiers
{
    //public const int asd = 1;
    public const int KeyboardInputUpdate = 1;
}

static public class KeyboardInputDirections
{
    public const int UP = 1;
    public const int DOWN = 2;
    public const int LEFT = 3;
    public const int RIGHT = 4;
    public const int UPRIGHT = 5;
    public const int UPLEFT = 6;
    public const int DOWNRIGHT = 7;
    public const int DOWNLEFT = 8;
    public const int NoPress = 100;
}
#endregion

