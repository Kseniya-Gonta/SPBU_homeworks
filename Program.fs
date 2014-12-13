

open System
open System.IO  
open System.Windows.Forms
open System.Drawing
open Verifier.Core.Verifier
open System.Runtime.InteropServices// скрыть консоль

[<DllImport("kernel32.dll")>] extern bool FreeConsole() //скрыть консоль
FreeConsole() |> ignore// скрыть консоль

let myForm = new Form(Width= 450, Height = 600, Visible = true, Text = "Email verifier", BackColor = Color.AntiqueWhite)

let textA = new TextBox( BackColor = Color.Bisque, Size = Size(200, 20), Location= Point(130, 140))
myForm.Controls.Add(textA)



let answerer = new Label(BackColor = Color.Bisque, Size = Size(200, 20), Location= Point(130, 240))
myForm.Controls.Add(answerer)


let button = new Button( Size = Size(100, 50), Location= Point(180, 180), BackColor = Color.BurlyWood, Text = "Check Email")
button.Click.Add(fun _ ->
  // Generate random color and set it as background
  let rnd = new Random()
  let r, g, b = rnd.Next(256), rnd.Next(256), rnd.Next(256)
  myForm.BackColor <- Color.FromArgb(r, g, b)
  let check = Verifier.Core.Verifier.IsValid (textA.Text)  
  let answer check = if check then  "Correct" else "Incorrect"
  answerer.Text <- answer check
  )
myForm.Controls.Add(button)

Application.Run(myForm)








