# C\# Coding Challenge
This repository contains some coding challenge done in `C#`.

## .NET
### Version
`8.0.404`
### Scripts
**Build Script**
> `dotnet build`

**Test Script**
> `dotnet test`

## Problems
### Old Phone Keypad
Here is an old phone keypad with alphabetical letters, a backspace key, and a send button. Each button has a number to identify it and pressing a button multiple times will cycle through the letters on it allowing each button to represent more than one letter. For example, pressing `2` once will return `A` but pressing twice in succession will return `B`. You must pause for a second in order to type two characters from the same button after each other: `222 2 22 -> "CAB"`.

![old phone keypad](keypad.png "Old Phone Keypad")

#### Prompt
Please design and document a class of method that will turn any input to `OldPhonePad` into the correct output. Assume that a send `#` will always be included at the end of every input.

```c#
public static string input String OldPhonePad( ) {
    // Please write your implementation here!
}
```

#### Examples
```
OldPhonePad("33#") => output: E
OldPhonePad("227*#") => output: B
OldPhonePad("4433555 555666#") => output: HELLO
OldPhonePad("8 88777444666*664#") => output: TURING
```

#### Solution
##### Solution Function
```
Challenges
    OldPhoneKeypad
        OldPhoneKeypad.cs
            public static string OldPhonePad(string input)
```

##### Test Cases
```
Challenges.Tests
    OldPhoneKeypad
        OldPhonePadShould.cs
```

##### Assumptions Expressed in Test Cases

- **`ReturnPunctuation_InputsWith1`**  
  In the phone image, the key `1` is shown with the punctuation `&'(`. This test case covers scenarios where the input contains `1`, returning the corresponding punctuation.

- **`ReturnSpace_InputsWith0`**  
  Similar to the previous case, `0` is mapped to `' '` (space). This test case ensures that the input `0` correctly returns a space.

- **`Handle_InputsWithMissingHash`**  
  Although the problem explicitly mentions that the input will always end with a `#`, I decided to handle cases where the `#` is missing.

- **`Handle_InputsWithHashInTheMiddle`**  
  Like the previous case, this test handles inputs where a `#` appears in the middle. In such cases, the input before the `#` is processed, and the rest is ignored.

- **`Handle_InputsWithMoreThanCharCountKeyPress`**  
  If a key is pressed more times than the number of characters mapped to it, the selection cycles through the mapped characters. For example, if `2` is pressed 4 times, it follows this cycle: `A → B → C → A`.

- **`Handle_InputsWithNonDigitChars`**  
  While non-digit characters could be considered invalid input, I chose to ignore them and process only the valid digit characters.