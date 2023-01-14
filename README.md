# Wordle-solver
Pretty self explanatory.  
Based on the advanced algorithm, this code can greatly help you (whilst being productive with letters) find the word in "Wordle".  
**Keep in mind that it can only find 5-letter words.**  
*I am not reliable for any bugs that might happen, if they happen.*  
  
  
  
    
**Modes:**  
There are currently two modes, *Normal* and *Advanced*.  
I will briefly explain two of them.  
  
  
Normal:  
This mode, as it intoduces itself, is pretty basic.  
He checks the word list as it's written, alphabetically. Nothing more to add.  
  
  
*Advanced:*  
This mode can be easily triggered by a radio button named "Advance".  
This mode doesn't check txt files alphabetically. Rather it checks and chooses words based out of his letters.  
This mode has **TWO** sepperated files for his algorithm. One is for letter rank and the other is for word rank.
For example, I want a word that has **r** and **t** in it. When he found all candidates for an answer, he will proceed to  
give a word with most common letters there. He gives me an answer: **tarea**  
*He gave me that because the word contains a's, the most common (in a 5-letter word) english letter.*  
Besides r and t, which need to be there, he found most common word out of common letters.  
You can find more on [letters_rank](https://github.com/KnifeEater/Wordle-solver/blob/main/WORDLE%20SOLVER/bin/Debug/letters_rank.txt) and word_rank!  


*Few other settings:*  
This code also has two additional settings.  
First is to not show words with duplicate letters (unless specified that it has two r's, for example)  
Second is to show a textbox, where you can input letters that **can't** be in a word!  
  
  
  
**NOTE: EVERY INPUT THAT YOU MAKE IS NOT SPACED OUT**  
For instance, in previous example we searched for word with r and t.  
*In that example, you need to input it like this: "rt", without " or spaces.*  
  
  
**SOURCES:**
Finally, without a word libary, this code wouldn't be here.  
Please, check out [dwyl](https://github.com/dwyl) if you are interested in projects like these!  
  
  
**Please enjoy my code, and thank you for reading this!**
