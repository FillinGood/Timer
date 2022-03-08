using Microsoft.Win32;
using System.ComponentModel;

namespace Timer;

public partial class Form1 : Form {

    private MediaPlayer Player = new();
    private System.Windows.Forms.Timer timer;
    private TimeSpan Time = new(0);
    private bool Running = false;
    private TimeSpan Mem = new(0);

    public Form1() {
        timer = new() {
            Interval = 1000
        };
        timer.Tick += Timer_Tick;
        InitializeComponent();
        LoadTime();
        UpdateTime();
        if(!Win32.RegisterHotKey(Handle, 1, (uint)Win32.ModifierKeys.Ctrl, (uint)Keys.Oem5)) {
            throw new Exception("Unable to register hotkey");
        }
    }

    protected override void OnClosing(CancelEventArgs e) {
        base.OnClosing(e);
        Win32.UnregisterHotKey(Handle, 1);
    }

    protected override void OnShown(EventArgs e) {
        base.OnShown(e);
        Focus();
        TopMost = true;
    }

    protected override void WndProc(ref Message m) {
        base.WndProc(ref m);
        if(m.Msg == Win32.WM_HOTKEY) {
            Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
            Win32.ModifierKeys mod = (Win32.ModifierKeys)((int)m.LParam & 0xFFFF);
            if(key == Keys.Oem5 && mod == Win32.ModifierKeys.Ctrl) {
                bStart.PerformClick();
            }
        }
    }

    private void Timer_Tick(object? sender, EventArgs e) {
        Dec(TimeRank.Seconds);
        if(Time.TotalSeconds > 0)
            return;
        StopTimer();

    }

    private void StopTimer() {
        timer.Stop();
        bStart.Text = "Start";
        bStop.Enabled = false;
        Time = Mem;
        UpdateTime();
        tbHours.Enabled = true;
        tbMinutes.Enabled = true;
        tbSeconds.Enabled = true;
        Player.Play();
        // ебать почините звук
        //MessageBox.Show(this, "Timer expired", "Timer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        new MsgBox(this).ShowDialog(this);
    }

    private void UpdateTime() {
        if(Time.TotalSeconds < 0) {
            Time = TimeSpan.Zero;
        }
        bStart.Enabled = Time.TotalSeconds > 0;
        tbHours.Text = ((int)Math.Floor(Time.TotalHours)).ToString("00");
        tbMinutes.Text = Time.ToString("mm");
        tbSeconds.Text = Time.ToString("ss");
    }

    private void Inc(TimeRank rank) {
        Time = Time.Add(rank switch {
            TimeRank.Seconds => TimeSpan.FromSeconds(1),
            TimeRank.Minutes => TimeSpan.FromMinutes(1),
            TimeRank.Hours => TimeSpan.FromHours(1),
            _ => TimeSpan.Zero
        });
        UpdateTime();
    }
    private void Dec(TimeRank rank) {
        Time = Time.Subtract(rank switch {
            TimeRank.Seconds => TimeSpan.FromSeconds(1),
            TimeRank.Minutes => TimeSpan.FromMinutes(1),
            TimeRank.Hours => TimeSpan.FromHours(1),
            _ => TimeSpan.Zero
        });
        UpdateTime();
    }

    private void panel1_MouseEnter(object sender, EventArgs e) {
        panel1.BackColor = SystemColors.ControlDark;
    }

    private void panel1_MouseLeave(object sender, EventArgs e) {
        panel1.BackColor = SystemColors.Control;
    }

    private void panel1_MouseClick(object sender, MouseEventArgs e) {
        Close();
    }

    private void Form1_MouseDown(object sender, MouseEventArgs e) {
        if(e.Button == MouseButtons.Left) {
            Win32.ReleaseCapture();
            Win32.SendMessage(Handle, Win32.WM_NCLBUTTONDOWN, Win32.HT_CAPTION, 0);
        }
    }

    private void tbHours_TextChanged(object sender, EventArgs e) {
        int hours = tbHours.Text == "" ? 0 : int.Parse(tbHours.Text);
        Time = new(hours, Time.Minutes, Time.Seconds);
    }

    private void tbMinutes_TextChanged(object sender, EventArgs e) {
        int minutes = tbMinutes.Text == "" ? 0 : int.Parse(tbMinutes.Text);
        Time = new((int)Math.Floor(Time.TotalHours), minutes, Time.Seconds);

    }

    private void tbSeconds_TextChanged(object sender, EventArgs e) {
        int seconds = tbSeconds.Text == "" ? 0 : int.Parse(tbSeconds.Text);
        Time = new((int)Math.Floor(Time.TotalHours), Time.Minutes, seconds);

    }

    private readonly Keys[] AllowedKeys = new[] {
        Keys.D0,Keys.NumPad0,
        Keys.D1,Keys.NumPad1,
        Keys.D2,Keys.NumPad2,
        Keys.D3,Keys.NumPad3,
        Keys.D4,Keys.NumPad4,
        Keys.D5,Keys.NumPad5,
        Keys.D6,Keys.NumPad6,
        Keys.D7,Keys.NumPad7,
        Keys.D8,Keys.NumPad8,
        Keys.D9,Keys.NumPad9,
        Keys.Back,Keys.Delete,
        Keys.Home,Keys.End,
        Keys.Left,Keys.Right,Keys.Up,Keys.Down,
        Keys.Enter
    };
    private void TimeKeyDown(object sender, KeyEventArgs e) {
        //System.Diagnostics.Debug.WriteLine($"{e.KeyCode} {e.KeyValue} {e.KeyData}");
        bool isdigit = AllowedKeys.Contains(e.KeyCode);
        if(!isdigit) {
            e.SuppressKeyPress = true;
            e.Handled = true;
        }
        if(e.KeyCode == Keys.Up) {
            Inc(
                sender == tbHours ? TimeRank.Hours :
                sender == tbMinutes ? TimeRank.Minutes :
                TimeRank.Seconds
            );
        }
        if(e.KeyCode == Keys.Down) {
            Dec(
                sender == tbHours ? TimeRank.Hours :
                sender == tbMinutes ? TimeRank.Minutes :
                TimeRank.Seconds
            );
        }
        if(e.KeyCode == Keys.Enter) {
            if(sender == tbHours) {
                tbMinutes.Focus();
            }
            if(sender == tbMinutes) {
                tbSeconds.Focus();
            }
            if(sender == tbSeconds) {
                UpdateTime();
            }
        }
    }

    private void TimeLostFocus(object sender, EventArgs e) {
        UpdateTime();
    }

    private void bStart_Click(object sender, EventArgs e) {
        if(Running) {
            Running = false;
            timer.Stop();
            bStart.Text = "Start";
            bStop.Enabled = true;
        } else {
            Running = true;
            timer.Start();
            bStart.Text = "Pause";
            bStop.Enabled = true;
            if(tbHours.Enabled) {
                tbHours.Enabled = false;
                tbMinutes.Enabled = false;
                tbSeconds.Enabled = false;
                Mem = Time;
                SaveTime();
            }
        }
    }

    private void bStop_Click(object sender, EventArgs e) {
        StopTimer();
    }

    private void LoadTime() {
        RegistryKey? root = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Fillin");
        if(root is null) {
            return;
        }
        string value = (string)root.GetValue("timer", "00:00:00")!;
        string[] split = value.Split(':');
        try {
            int hours = int.Parse(split[0]);
            int minutes = int.Parse(split[1]);
            int seconds = int.Parse(split[2]);
            Time = Mem = new(hours, minutes, seconds);
        } catch { }
    }

    private void SaveTime() {
        RegistryKey? root = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Fillin", RegistryKeyPermissionCheck.ReadWriteSubTree);
        if(root is null) {
            root = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Fillin");
        }
        int hours = (int)Math.Floor(Time.TotalHours);
        int minutes = Time.Minutes;
        int seconds = Time.Seconds;
        root.SetValue("timer", $"{hours:00}:{minutes:00}:{seconds:00}");
    }

}
public enum TimeRank { Seconds, Minutes, Hours }