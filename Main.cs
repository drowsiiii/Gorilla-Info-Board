
// before you look at this code, Huge props to Hansolo and Dount guy thing i forgor name for helping me a little
// huge thanks for me skidding the trick of using the rig text for the font, thanks GorillaStats!
// most code developed by drowsiii/vaeee 
// any bugs you fix.. pull req
// ingore the swears

using System;
using BepInEx;
using UnityEngine;
using static InfoBoard.Info;
using System.IO;
using System.Reflection;
using GorillaLocomotion;
using GorillaNetworking;
using Photon.Pun;
using TMPro;
using UnityEngine.Animations.Rigging;
using UnityEngine.UI;

namespace InfoBoard
{
    [BepInPlugin(InfoBoard.Info.Guid, Name, InfoBoard.Info.Version)]

    // notes: If your editing this code, dont remove ANY null checks unless you want the mod to give you what i call "The ice bug" funny bug dont try it, if you found a fix lmk @drowsiii_

    public class Main : BaseUnityPlugin
    {
        
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor SILENCED
#pragma warning disable CS0649 // Field is never assigned to SILENCED
#pragma warning disable CS0169 // Field is never used SILENCED
        public static Main Instance;
// shyt Connection / Status
        private bool Connected = false;
        private bool allowed;
        private string Status = "Not connected"; 
        private string RoomCode = "No Room";

// shyt Game-related strings
        private string MaxPlayers1 = "hiii";
        private string Gamemodeis = " nothing, there is no gamemode this is a coding envorment not gtag";
        private string Moddedlobby = "Modded";

// shyt GameObjects
        private GameObject RoomText = new GameObject("RoomText");
        private GameObject button;
        private GameObject newTextAboveButton;

// TextMeshPro shyt
        private TextMeshPro RoomTMP;
        private TextMeshPro MaxPlayers;
        private TextMeshPro GamemodeTMP;
        private TextMeshPro PlayeridTMP;
        private TextMeshPro Playerid1TMP;
        private TextMeshPro PlayerInfoHeadingTMP;
        private TextMeshPro tmp;
        private TextMeshPro RoomHeadingTMP;
        private TextMeshPro CreditsTMP;
        private TextMeshPro Page3HeadingTMP;
        private TextMeshPro FPSCounterTMP;
        private TextMeshPro PingDisplayTMP;
        private TextMeshPro SessionTimeTMP;
        private TextMeshPro newTextTMP;
        private TextMeshPro CosmeticsTMP;
        private TextMeshPro PlayerListHeadingTMP;
        private TextMeshPro PlayerListTMP;
        private TextMeshPro ModsHeadingTMP;
        private TextMeshPro ModsListTMP;
        
// shyt fucking lovign Page system
        private int MaxPages = 5; 
        public int pagenumber = 1;

// shyt Stats
        private float sessionStartTime;
        // shyt Asset Bundle
// shyt Asset Bundle Loader Class thing
        public static AssetBundle LoadAssetBundle(string path)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return bundle;
        }

// Page 1
        void HidePage1()
        {
            if (MaxPlayers != null)
            {
                MaxPlayers.enabled = false;
            }

            if (RoomTMP != null)
            {
                RoomTMP.enabled = false;
            }

            if (GamemodeTMP != null)
            {
                GamemodeTMP.enabled = false;
            }

            if (PlayeridTMP != null)
            {
                PlayeridTMP.enabled = false;
            }

            if (Playerid1TMP != null)
            {
                Playerid1TMP.enabled = false;
            }

            if (tmp != null)
            {
                tmp.enabled = false;
            }

            if (PlayerInfoHeadingTMP != null)
            {
                PlayerInfoHeadingTMP.enabled = false;
            }

            if (RoomHeadingTMP != null)
            {
                RoomHeadingTMP.enabled = false;
            }
        }

        void ShowPage1()
        {
            if (MaxPlayers != null)
            {
                MaxPlayers.enabled = true;
            }

            if (RoomTMP != null)
            {
                RoomTMP.enabled = true;
            }

            if (GamemodeTMP != null)
            {
                GamemodeTMP.enabled = true;
            }

            if (PlayeridTMP != null)
            {
                PlayeridTMP.enabled = true;
            }

            if (Playerid1TMP != null)
            {
                Playerid1TMP.enabled = true;
            }

            if (tmp != null)
            {
                tmp.enabled = true;
            }

            if (PlayerInfoHeadingTMP != null)
            {
                PlayerInfoHeadingTMP.enabled = true;
            }

            if (RoomHeadingTMP != null)
            {
                RoomHeadingTMP.enabled = true;
            }
        }

// Page 2
        void HidePage5()
        {
            if (CreditsTMP != null)
            {
                CreditsTMP.enabled = false;
            }
        }

        void ShowPage5()
        {
            if (CreditsTMP != null)
            {
                CreditsTMP.enabled = true;
            }
        }

        // READ:
        // how the pages work, 
        // basically you make a function for the pages so like showpage? and hide, then the next pge you should call for changing pages it make sure you change the max page number
        // this is mainly for myself but if you see this DONT BREAK THE PAGES i love themm!! <3 - drowsiii and the non existent "vaaee"
        public void NextPage() //  this took me too long and im procansating  
        {
            pagenumber += 1;
            if (pagenumber > MaxPages) pagenumber = 1;
            UpdatePages();
            
        }

// ==========================================
// PAGE 3 SYSTEM - Add these methods
// ==========================================

// Page 3
        void HidePage3()
        {
            if (Page3HeadingTMP != null)
            {
                Page3HeadingTMP.enabled = false;
            }
    
            if (FPSCounterTMP != null)
            {
                FPSCounterTMP.enabled = false;
            }
    
            if (PingDisplayTMP != null)
            {
                PingDisplayTMP.enabled = false;
            }
    
            if (SessionTimeTMP != null)
            {
                SessionTimeTMP.enabled = false;
            }
            if (CosmeticsTMP != null)
            {
                CosmeticsTMP.enabled = false;
            }
        }

        void ShowPage3()
        {
            if (Page3HeadingTMP != null)
            {
                Page3HeadingTMP.enabled = true;
            }
    
            if (FPSCounterTMP != null)
            {
                FPSCounterTMP.enabled = true;
            }
    
            if (PingDisplayTMP != null)
            {
                PingDisplayTMP.enabled = true;
            }
    
            if (SessionTimeTMP != null)
            {
                SessionTimeTMP.enabled = true;
            }
            if (CosmeticsTMP != null)
            {
                CosmeticsTMP.enabled = true;
            }
        }
        
        // page fucking 4
        // Page 4
        void HidePage4()
        {
            if (PlayerListHeadingTMP != null)
            {
                PlayerListHeadingTMP.enabled = false;
            }
            if (PlayerListTMP != null)
            {
                PlayerListTMP.enabled = false;
            }
        }

        void ShowPage4()
        {
            if (PlayerListHeadingTMP != null)
            {
                PlayerListHeadingTMP.enabled = true;
            }
            if (PlayerListTMP != null)
            {
                PlayerListTMP.enabled = true;
            }
        }
        
        
        // Page 5
        void HidePage2()
        {
            if (ModsHeadingTMP != null)
            {
                ModsHeadingTMP.enabled = false;
            }
            if (ModsListTMP != null)
            {
                ModsListTMP.enabled = false;
            }
        }

        void ShowPage2()
        {
            if (ModsHeadingTMP != null)
            {
                ModsHeadingTMP.enabled = true;
            }
            if (ModsListTMP != null)
            {
                ModsListTMP.enabled = true;
            }
        }
        
// ==========================================
// ==========================================
        public void UpdatePages()
        {
            HidePage1();
            HidePage2();
            HidePage3();
            HidePage4();
            HidePage5(); // Add this
            if (pagenumber == 1) ShowPage1();
            else if (pagenumber == 2) ShowPage2();
            else if (pagenumber == 3) ShowPage3();
            else if (pagenumber == 4) ShowPage4();
            else if (pagenumber == 5) ShowPage5(); // Add this
            newTextTMP.text = $"Current Page = {pagenumber}";
        }


        private void OnGUI()
        {


            if (GUI.Button(new Rect(10f, 10f, 120f, 40f),
                    "Next Page")) // found ui online couldnt be bothered doing it myself, thanks reddit post 
            {
                NextPage();
            }

            GUI.Label(new Rect(10f, 10f + 40f + 5f, 120f, 20f), "Page: " + pagenumber); // 
        }

        private void Awake()
        {
            GorillaTagger.OnPlayerSpawned(Init);
        }



        private void Update()
        {
            var calculationframes = 1f / Time.unscaledDeltaTime;
            var frames = makenotsobigbruh((int)calculationframes);
            FPSCounterTMP.text = $"Current Frames: {frames}";
            int ping;
            if (PhotonNetwork.InRoom)
            {
                ping = PhotonNetwork.GetPing();
                PingDisplayTMP.text = $"Ping: {ping}ms";
            }
            else
            {
                PingDisplayTMP.text = $"Not Connected";
            }
            TimeSpan timeElapsed = TimeSpan.FromSeconds(Time.time - sessionStartTime);
            // Thanks actual vaeee
            string makenotsobigbruh(int value)
            {
                if (value < 1000) return value.ToString();
                return (value / 1000) + "k";
            }
            
            string hours   =  makenotsobigbruh((int)timeElapsed.TotalHours);
            string minutes =  makenotsobigbruh(timeElapsed.Minutes);
            string seconds =  makenotsobigbruh(timeElapsed.Seconds);
            string ms      =  makenotsobigbruh(timeElapsed.Milliseconds);

            SessionTimeTMP.text = $"Session Time: {hours}h : {minutes}m : {seconds}s : {ms}ms";
            var cosmeticsList1 = GorillaTagger.Instance.offlineVRRig.cosmetics;
            int allowedCount = 0;
            int disallowedCount = 0;
            foreach (var cosmetics in cosmeticsList1) // this is fucking unoptimized
            {
                if (VRRig.LocalRig.IsItemAllowed(cosmetics.name)) // needed??
                {
                    allowedCount++;
                }
                else
                {
                    disallowedCount++;
                }
                    
            }
            CosmeticsTMP.text = $"Cosmetics Allowed: {allowedCount} | Disallowed: {disallowedCount}";
            Color playerColor = GorillaTagger.Instance.offlineVRRig.playerColor;
            int r = Mathf.RoundToInt(playerColor.r * 9);
            int g = Mathf.RoundToInt(playerColor.g * 9);
            int b = Mathf.RoundToInt(playerColor.b * 9);

            Playerid1TMP.text = $"Color Code: {r}, {g}, {b}";

        }



        void Init()
        {
            Instance = this;
            // you on game start functions here
            var bundle = LoadAssetBundle("InfoBoard.Assets.Boards.bundle"); // ty real vaee
            if (bundle == null)
            {
                Logger.LogError(
                    "❌  not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle not found in not bundle' not found in not bundle.");
                return;
            }

            var asset = bundle.LoadAsset<GameObject>("Board");
            if (asset == null)
            {
                Logger.LogError("❌ Prefab 'Board' not found in bundle."); //  you
                return;
            }

            var Pos = new Vector3(-63.706f, 12.6442f, -81.800f);
            var Board = Instantiate(asset, Pos, Quaternion.Euler(0, 270, 0));
            Board.name = "Board";
            Board.transform.localScale = new Vector3(0.10f, 0.10f, 0.10f);
// ==========================================
// Button making and shyt please some1 remake this
// ==========================================
            GameObject buttonObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            var sahderbutton = buttonObject.GetComponent<Renderer>();
            sahderbutton.material = new Material(Shader.Find("GorillaTag/UberShader"));
            buttonObject.AddComponent<ButtonPageChanger>();
            buttonObject.transform.position = new Vector3(-64.215f, 12.4442f, -81.800f);
            buttonObject.transform.localScale = new Vector3(0.25f, 0.05f, 0.05f);
            
            // Text Change Page
            // Add this after your button creation code
            GameObject buttonLabel222 = new GameObject("ButtonLabel");
            TextMeshPro buttonText111 = buttonLabel222.AddComponent<TextMeshPro>();
            buttonText111.text = "Change Page";
            buttonText111.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;
            buttonText111.fontSize = 0.9f;
            buttonText111.color = Color.black;
            buttonText111.alignment = TextAlignmentOptions.Center;
            buttonLabel222.transform.position = new Vector3(-64.215f, 12.4442f, -81.837f); 
            buttonLabel222.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
            buttonLabel222.transform.Rotate(0, 0, 0);

            newTextAboveButton = new GameObject("TextAboveButton"); newTextTMP = newTextAboveButton.AddComponent<TextMeshPro>();
            newTextTMP.text = "Current Page = 1"; // Change this to whatever you want to display
            newTextTMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;
            newTextTMP.fontSize = 1.7f; // Slightly smaller than headings but bigger than regular text
            newTextTMP.color = new Color(200/255f, 170/255f, 220/255f);
            newTextTMP.alignment = TextAlignmentOptions.Center;
            newTextAboveButton.transform.position = new Vector3(-64.225f, 12.4942f, -81.827f);
            newTextAboveButton.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
            newTextAboveButton.transform.Rotate(0, 0, 0);
            // Text
            // edit pain in my ass
            // Lil text guide for self (edit: )
            /*
              How to move board text up/down:
              Middle Number in new Vector3(1st, middle, 3(DONT TOUCH LAST NUMBER))
              Dont touch last number AT ALL
              The first number is across/ sideways
              Removeing numbers from first is im pretty sure is this way (<----)
              And adding is (---->)

             */
            GameObject Credits = new GameObject("Credits");
            CreditsTMP = Credits.AddComponent<TextMeshPro>();

            CreditsTMP.text = 
                "- CREDITS -\n" +
                "════════════════════════════════════\n\n" +
                "anonymous.hi - Discord\n" +
                "----------------------------------------\n" +
                "Massive thanks for all the help!\n" +
                "• Current gamemode detection system\n" +
                "• GorillaPressableButton implementation\n" +
                "• General coding guidance & support\n\n" +

                "drowsiii/vaeee - Developer\n" +
                "----------------------------------------\n" +
                "Main development & coding\n\n" +

                "════════════════════════════════════\n" +
                "Additional credits in source code comments";
            CreditsTMP.font =
                GorillaTagger.Instance.offlineVRRig.playerText1
                    .font; // Straight up skidded from gorillastats tyy!, you should go get it, Sorry..
            CreditsTMP.fontSize = 1.7f;
            CreditsTMP.color = Color.white;
            CreditsTMP.alignment = TextAlignmentOptions.Center;
            Credits.transform.position =
                new Vector3(-63.706f, 12.6942f, -81.827f); // -81.827f is flush to the board, i repeat dont change it
            Credits.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
            Credits.transform.Rotate(0, 0, 0);
            CreditsTMP.enabled = false;
            // Vector3 front4 = Pos + Board.transform.forward * 2.2f; // => (-67.706, 12.6442, -81.800) ty!! calc (This is wrong  me)
            GameObject label1 = new GameObject("TMP Text");
            tmp = label1.AddComponent<TextMeshPro>(); // all i had to ducing tofccuckufck
            tmp.text = "Gorilla Info Board v1.0.0";
            tmp.font = GorillaTagger.Instance.offlineVRRig.playerText1
                .font; // Straight up skidded from gorillastats tyy!, you should go get it, Sorry..
            tmp.fontSize = 3;
            tmp.color = Color.white;
            tmp.alignment = TextAlignmentOptions.Center;
            label1.transform.position =
                new Vector3(-63.944f, 12.8541f, -81.827f); // -81.827f is flush to the board, i repeat dont change it
            label1.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
            label1.transform.Rotate(0, 0, 0);
            // -------------------------
            // Room shyt
            // -------------------------
            GameObject RoomHeading = new GameObject("TMPRoomHeading");
            RoomHeadingTMP = RoomHeading.AddComponent<TextMeshPro>(); // all i had to ducing tofccuckufck
            RoomHeadingTMP.text = "Room Info:";
            RoomHeadingTMP.font =
                GorillaTagger.Instance.offlineVRRig.playerText1
                    .font; // Straight up skidded from gorillastats tyy!, you should go get it, Sorry..
            RoomHeadingTMP.fontSize = 2.3f;
            RoomHeadingTMP.color = Color.white;
            RoomHeadingTMP.alignment = TextAlignmentOptions.Center;
            RoomHeading.transform.position =
                new Vector3(-63.944f, 12.7541f, -81.827f); // -81.827f is flush to the board, i repeat dont change it
            RoomHeading.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
            RoomHeading.transform.Rotate(0, 0, 0);
            // Second Text workies
            GameObject RoomText = new GameObject("RoomText");
            RoomTMP = RoomText.AddComponent<TextMeshPro>();
            RoomTMP.text = $"{Status}";
            RoomTMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;
            RoomTMP.fontSize = 2;
            RoomTMP.color = Color.white;
            RoomTMP.alignment = TextAlignmentOptions.Center;
            RoomText.transform.position =
                new Vector3(-63.944f, 12.6541f, -81.827f); // -81.827f is flush to the board, i repeat dont change it
            RoomText.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
            RoomText.transform.Rotate(0, 0, 0);
            // Ice Bug Photonnetwork thing i think edit fixed
            GameObject MaxPlayersText = new GameObject("PlayersText");
            MaxPlayers = MaxPlayersText.AddComponent<TextMeshPro>();
            MaxPlayers.text = $"{MaxPlayers1}";
            MaxPlayers.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;
            MaxPlayers.fontSize = 2;
            MaxPlayers.color = Color.white;
            MaxPlayers.alignment = TextAlignmentOptions.Center;
            MaxPlayersText.transform.position =
                new Vector3(-63.944f, 12.6141f, -81.827f); // -81.827f is flush to the board, i repeat dont change it
            MaxPlayersText.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
            MaxPlayersText.transform.Rotate(0, 0, 0);
            GameObject GameMode = new GameObject("Gamemodething");
            GamemodeTMP = GameMode.AddComponent<TextMeshPro>();
            GamemodeTMP.text = $"Gamemode: {Gamemodeis}";
            GamemodeTMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;
            GamemodeTMP.fontSize = 2;
            GamemodeTMP.color = Color.white;
            GamemodeTMP.alignment = TextAlignmentOptions.Center;
            GameMode.transform.position =
                new Vector3(-63.944f, 12.5741f, -81.827f); // -81.827f is flush to the board, i repeat dont change it
            GameMode.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
            GameMode.transform.Rotate(0, 0, 0);
            // -------------------------
            // Player info!
            // ------------------------- has ice bug?
            string
                  PlayerID = PhotonNetwork.LocalPlayer .UserId; // HOW THE  DOES THIS  THE    WORKKKK SOMEONE PLEASE TEACH ME THE ASSEMBLY
            




            GameObject PlayerInfoHeading = new GameObject("PlayerInfoHeading");
            PlayerInfoHeadingTMP = PlayerInfoHeading.AddComponent<TextMeshPro>(); // all i had to ducing tofccuckufck
            PlayerInfoHeadingTMP.text = "Player Info:";
            PlayerInfoHeadingTMP.font =
                GorillaTagger.Instance.offlineVRRig.playerText1
                    .font; // Straight up skidded from gorillastats tyy!, you should go get it, Sorry..
            PlayerInfoHeadingTMP.fontSize = 2f;
            PlayerInfoHeadingTMP.color = Color.white;
            PlayerInfoHeadingTMP.alignment = TextAlignmentOptions.Center;
            PlayerInfoHeading.transform.position =
                new Vector3(-63.400f, 12.7501f, -81.827f); // -81.827f is flush to the board, i repeat dont change it
            PlayerInfoHeading.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
            PlayerInfoHeading.transform.Rotate(0, 0, 0);
            GameObject NahIdPlayerId = new GameObject("PlayerID"); // Ice bug
            PlayeridTMP = NahIdPlayerId.AddComponent<TextMeshPro>();
            PlayeridTMP.text = "<color=#FF4444>Player ID:</color> " + PhotonNetwork.LocalPlayer.UserId;
            PlayeridTMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;
            PlayeridTMP.fontSize = 2;
            PlayeridTMP.color = Color.white;
            PlayeridTMP.alignment = TextAlignmentOptions.Center;
            NahIdPlayerId.transform.position =
                new Vector3(-63.400f, 12.6541f, -81.827f); // -81.827f is flush to the board, i repeat dont change it
            NahIdPlayerId.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
            NahIdPlayerId.transform.Rotate(0, 0, 0);
            GameObject NahIdcolord = new GameObject("colorcode"); // Ice bug
            Playerid1TMP = NahIdcolord.AddComponent<TextMeshPro>();
            Playerid1TMP.text = "no"; // dont work
            Playerid1TMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;
            Playerid1TMP.fontSize = 2;
            Playerid1TMP.color = Color.white;
            Playerid1TMP.alignment = TextAlignmentOptions.Center;
            NahIdcolord.transform.position =
                new Vector3(-63.400f, 12.6141f, -81.827f); // -81.827f is flush to the board, i repeat dont change it
            NahIdcolord.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
            NahIdcolord.transform.Rotate(0, 0, 0);

            // -------------------------
            // Performance & Info
            // -------------------------
            GameObject Page3Heading = new GameObject("Page3Heading");
            Page3HeadingTMP = Page3Heading.AddComponent<TextMeshPro>();
            Page3HeadingTMP.text = "Performance & Other Info";
            Page3HeadingTMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;
            Page3HeadingTMP.fontSize = 2.3f;
            Page3HeadingTMP.color = Color.white;
            Page3HeadingTMP.alignment = TextAlignmentOptions.Center;
            Page3Heading.transform.position = new Vector3(-63.706f, 12.8041f, -81.827f); 
            Page3Heading.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
            Page3Heading.transform.Rotate(0, 0, 0);
            Page3HeadingTMP.enabled = false;


            GameObject FPSCounter = new GameObject("FPSCounter");
            FPSCounterTMP = FPSCounter.AddComponent<TextMeshPro>();
                FPSCounterTMP.text = "FPS: 90";
                    FPSCounterTMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font; // hiii :D
                        FPSCounterTMP.fontSize = 2f;
                    FPSCounterTMP.color = new Color(0.3f, 1f, 0.3f); 
                FPSCounterTMP.alignment = TextAlignmentOptions.Center;
            FPSCounter.transform.position = new Vector3(-63.706f, 12.6641f, -81.827f); 
            FPSCounter.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
            FPSCounter.transform.Rotate(0, 0, 0);
            FPSCounterTMP.enabled = false;

            GameObject PingDisplay = new GameObject("PingDisplay");
            PingDisplayTMP = PingDisplay.AddComponent<TextMeshPro>();
            PingDisplayTMP.text = "Ping: -- ms";
            PingDisplayTMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;
            PingDisplayTMP.fontSize = 2f;
            PingDisplayTMP.color = new Color(1f, 0.8f, 0.3f); 
            PingDisplayTMP.alignment = TextAlignmentOptions.Center;
            PingDisplay.transform.position = new Vector3(-63.706f, 12.7041f, -81.827f); 
            PingDisplay.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
            PingDisplay.transform.Rotate(0, 0, 0);
            PingDisplayTMP.enabled = false;


            GameObject SessionTime = new GameObject("SessionTime");
            SessionTimeTMP = SessionTime.AddComponent<TextMeshPro>();
            SessionTimeTMP.text = "Session: 00:00";
            SessionTimeTMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;
            SessionTimeTMP.fontSize = 2f;
            SessionTimeTMP.color = new Color(0.3f, 0.8f, 1f); 
            SessionTimeTMP.alignment = TextAlignmentOptions.Center;
            SessionTime.transform.position = new Vector3(-63.706f, 12.6241f, -81.827f); 
            SessionTime.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
            SessionTime.transform.Rotate(0, 0, 0);
            SessionTimeTMP.enabled = false;
            
            // New Text Under Session Time
            GameObject gameObjectCosmeticsTMP = new GameObject("NewTextUnderSession"); 
            CosmeticsTMP = gameObjectCosmeticsTMP.AddComponent<TextMeshPro>();
            CosmeticsTMP.text = "Cosmetics Amount: Error, Reload the mod?"; // Change
            CosmeticsTMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;
            CosmeticsTMP.fontSize = 2f;
            CosmeticsTMP.color = new Color(1f, 0.5f, 0.8f); //
            CosmeticsTMP.alignment = TextAlignmentOptions.Center;
            gameObjectCosmeticsTMP.transform.position = new Vector3(-63.706f, 12.5841f, -81.827f); // 0.04f
            gameObjectCosmeticsTMP.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
            gameObjectCosmeticsTMP.transform.Rotate(0, 0, 0);
            CosmeticsTMP.enabled = false;
            
            // -------------------------
//   - Player List
// -------------------------
            GameObject PlayerListHeading = new GameObject("PlayerListHeading");
            PlayerListHeadingTMP = PlayerListHeading.AddComponent<TextMeshPro>();
            PlayerListHeadingTMP.text = "Player List:";
            PlayerListHeadingTMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;
            PlayerListHeadingTMP.fontSize = 2.3f;
            PlayerListHeadingTMP.color = Color.white;
            PlayerListHeadingTMP.alignment = TextAlignmentOptions.Center;
            PlayerListHeading.transform.position = new Vector3(-63.706f, 12.8041f, -81.827f); 
            PlayerListHeading.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
            PlayerListHeading.transform.Rotate(0, 0, 0);
            PlayerListHeadingTMP.enabled = false;

            GameObject PlayerList = new GameObject("PlayerList");
            PlayerListTMP = PlayerList.AddComponent<TextMeshPro>();
            PlayerListTMP.text = "Not in room";
            PlayerListTMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;
            PlayerListTMP.fontSize = 1.6f;
            PlayerListTMP.color = Color.white;
            PlayerListTMP.alignment = TextAlignmentOptions.Center;
            PlayerList.transform.position = new Vector3(-63.706f, 12.6541f, -81.827f); // Centered position
            PlayerList.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
            PlayerList.transform.Rotate(0, 0, 0);
            PlayerListTMP.enabled = false;
            
            // -------------------------
            // Installed Mods
            // -------------------------
            GameObject ModsHeading = new GameObject("ModsHeading");
            ModsHeadingTMP = ModsHeading.AddComponent<TextMeshPro>();
            ModsHeadingTMP.text = "Installed Mods:";
            ModsHeadingTMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;
            ModsHeadingTMP.fontSize = 2.3f;
            ModsHeadingTMP.color = Color.white;
            ModsHeadingTMP.alignment = TextAlignmentOptions.Center;
            ModsHeading.transform.position = new Vector3(-63.706f, 12.7541f, -81.827f);
            ModsHeading.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
            ModsHeading.transform.Rotate(0, 0, 0);
            ModsHeadingTMP.enabled = false;
            var GUIDS = BepInEx.Bootstrap.Chainloader.PluginInfos; // thnaks copoilt search i fcuking hate you but ty :D
            string guidstrings = "";
            foreach(var GUIDs in GUIDS.Values)
            {
                guidstrings += $"\n {GUIDs}";
            }
            // get installed GUIDS? ty google
            GameObject ModsList = new GameObject("ModsList");
            ModsListTMP = ModsList.AddComponent<TextMeshPro>();
            ModsListTMP.text = guidstrings;
            ModsListTMP.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;
            ModsListTMP.fontSize = 1.8f; // Smaller font for list
            ModsListTMP.color = Color.white;
            ModsListTMP.alignment = TextAlignmentOptions.Center;
            ModsList.transform.position = new Vector3(-63.706f, 12.6241f, -81.827f);
            ModsList.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
            ModsList.transform.Rotate(0, 0, 0);
            ModsListTMP.enabled = false;

            Debug.Log("game initialized");

            // subscribe to join/leave room events
            NetworkSystem.Instance.OnMultiplayerStarted += JoinedRoom;
            NetworkSystem.Instance.OnReturnedToSinglePlayer += OnLeaveRoom;
        }

        
        // #freeschelp
        // 
        /* private string GetGamemodeKey(string gamemodeString) // Credits to hansolo1000falcon for ebing the best and improving this and credits to Dount @anonymous.hi for being the best and making first avation code
         { // should workies
             if (gamemodeString.Contains("CASUAL")) return "CASUAL";
             if (gamemodeString.Contains("INFECTION")) return "INFECTION";
             if (gamemodeString.Contains("HUNT")) return "HUNT";
             if (gamemodeString.Contains("Freeze")) return "FREEZE";
             if (gamemodeString.Contains("PAINTBRAWL")) return "PAINTBRAWL";
             if (gamemodeString.Contains("AMBUSH")) return "AMBUSH";
             if (gamemodeString.Contains("GHOST")) return "GHOST";
             if (gamemodeString.Contains("GUARDIAN")) return "GUARDIAN";
             return gamemodeString; sorry hansolo your methord no work for my use */

        void FixedUpdate()
        {
            
            Color playerColor = GorillaTagger.Instance.offlineVRRig.playerColor;
            int r = Mathf.RoundToInt(playerColor.r * 9);
            int g = Mathf.RoundToInt(playerColor.g * 9);
            int b = Mathf.RoundToInt(playerColor.b * 9);

            Playerid1TMP.text = $"Color Code: {r}, {g}, {b}"; // maybbeee...
            // Keep text  working 
            if (RoomTMP != null)
                RoomTMP.text = Status;
            if (PlayeridTMP != null && PhotonNetwork.LocalPlayer != null && PhotonNetwork.LocalPlayer.UserId != null)
            {
                PlayeridTMP.text = "<color=#FF4444>Player ID:</color> " + PhotonNetwork.LocalPlayer.UserId;
            }

            if (Connected) // welcome back old unc
            {

                string gm = NetworkSystem.Instance.GameModeString.ToUpperInvariant();

                if (gm.Contains("CASUAL"))          Gamemodeis = "Casual"; // ty hansolo! realised i dont need {}
                else if (gm.Contains("INFECTION"))  Gamemodeis = "Infection";
                else if (gm.Contains("HUNT"))       Gamemodeis = "Hunt";
                else if (gm.Contains("FREEZE"))     Gamemodeis = "Freeze Tag";
                else if (gm.Contains("GUARDIAN"))   Gamemodeis = "Guardian";
                else if (gm.Contains("PAINTBRAWL")) Gamemodeis = "Paint Brawl";
                else if (gm.Contains("AMBUSH"))     Gamemodeis = "Ambush";
                else if (gm.Contains("GHOST"))      Gamemodeis = "Ghost";
                else                                Gamemodeis = NetworkSystem.Instance.GameModeString;
                
                if (allowed)
                {
                    GamemodeTMP.text = $"Gamemode: {Moddedlobby} {Gamemodeis}";
                }
                else if (gm.Contains("MODDED"))
                {
                    GamemodeTMP.text = $"Gamemode: Modded {Gamemodeis}";
                }
                else
                {
                    GamemodeTMP.text = $"Gamemode: {Gamemodeis}";
                }

            }
            else
            {
                Gamemodeis = "Not In Room";
                GamemodeTMP.text = Gamemodeis;
            }

            if (Connected)
            {
                int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
                MaxPlayers1 = playerCount + " / 10";
                MaxPlayers.text = MaxPlayers1;
                string PlayerListfrthistime = ""; // fuck
                foreach (var player in PhotonNetwork.PlayerList)
                {
                    PlayerListfrthistime += $"\n Name: {player.NickName} <||> Master Client: {player.IsMasterClient} <||> User ID: {player.UserId}";
                }
                PlayerListTMP.text = PlayerListfrthistime;
            }
            else
            {
                MaxPlayers.text = "Not in Room";
                PlayerListTMP.text = "Not in Room";
            }
        }

        void JoinedRoom()
        {
            Connected = true;
            allowed = NetworkSystem.Instance.GameModeString.Contains("MODDED");
            RoomCode = PhotonNetwork.CurrentRoom.Name;
            RoomTMP.fontSize = 1.7f;
            Status = $"Connected (Room: {RoomCode})";
            if (PlayeridTMP != null)
            {
                PlayeridTMP.text = "Player ID: " + PhotonNetwork.LocalPlayer.UserId;
            }
        }

        void OnLeaveRoom()
        {
            RoomTMP.fontSize = 2f;
            Connected = false;
            allowed = false;
            Status = "Not connected";
        }
    }

    internal class ButtonPageChanger : GorillaPressableButton // Anomynous Told this was from the maker of holdable pad! Thanks E10O!  and Anomynous
    {
        public override void Start()
        {
            gameObject.layer = 18;
        }

        public override void ButtonActivation()
        {
                Main.Instance.NextPage();
                Debug.Log("Button pressed! Page changed fucking to: " + Main.Instance.pagenumber);
        }
    }
}
 

