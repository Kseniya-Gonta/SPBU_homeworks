namespace Verifier.Core

open System.Text.RegularExpressions

module Verifier = 
   let username = "[a-z_](\.?\w+)*"
   let hostname = "([a-z]+\.)+(museum|name|info|aero|arpa|asia|biz|cat|com|coop|edu|gov|info|int|jobs|mil|mobi|museum|name|net|org|pro|tel|travel|[a-z]{2,3})"
   let regEx = "^" + username + "@" + hostname + "$"
   let example = new Regex(regEx, RegexOptions.IgnoreCase)
   let IsValid input = example.IsMatch(input)


  