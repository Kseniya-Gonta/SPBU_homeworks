

open System
open System.IO  
open System.Windows.Forms
open System.Drawing
open Verifier.Core.Verifier
open System.Runtime.InteropServices// скрыть консоль

[<DllImport("kernel32.dll")>] extern bool FreeConsole() //скрыть консоль
FreeConsole() |> ignore// скрыть консоль

let myForm = new Form(Width= 450, Height = 420, Visible = true, Text = "Email verifier", BackColor = Color.AntiqueWhite)

let textA = new TextBox( BackColor = Color.Bisque, Size = Size(250, 20), 
                            Location= Point(105, 140), Font = new Font(family = new FontFamily("Georgia"), emSize = 13.0f))
myForm.Controls.Add(textA)



let answerer = new Label(BackColor = Color.AntiqueWhite, Size = Size(120, 35), Location= Point(175, 260),
                             Font = new Font(family = new FontFamily("Georgia"), emSize = 18.0f))
myForm.Controls.Add(answerer)

let helper = new Label(BackColor = Color.AntiqueWhite, Text = "Type Email below:", 
                        Size = Size(250, 20), Location= Point(105, 105),
                        Font = new Font(family = new FontFamily("Georgia"), emSize = 13.0f))
myForm.Controls.Add(helper)

let button = new Button( Size = Size(100, 50), Location= Point(180, 190), BackColor = Color.BurlyWood, 
                            Text = "Check Email", Font = new Font(family = new FontFamily("Georgia"), emSize = 15.0f))
button.Click.Add(fun _ ->
  // Generate random color and set it as background
  let rnd = new Random()
  let r, g, b = rnd.Next(256), rnd.Next(256), rnd.Next(256)
  myForm.BackColor <- Color.FromArgb(r, g, b)
  answerer.BackColor <- Color.FromArgb(r, g, b)
  helper.BackColor <- Color.FromArgb(r, g, b)
  let check = Verifier.Core.Verifier.IsValid (textA.Text)  
  let answer check = if check then  "Correct!" else "Incorrect!"
  answerer.Text <- answer check
  helper.Text <- ""
  )
myForm.Controls.Add(button)

Application.Run(myForm)








