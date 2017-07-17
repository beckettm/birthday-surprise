using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllText : MonoBehaviour {

	public static string[] introText = new string[] {

		"Happy birthday Billy! Since you're turning 8, which is a very important age, " +
		"your mom and I have a big surprise for you! It's in your room. \n[SPACE]",

		"But to make things a little more interesting, we locked the door to your room " +
		"and hid the key! We set up a little treasure hunt to lead you to it. \n[SPACE]",

		"So find the clues hidden around the house, and you'll find your key! " +
		"Here's the first clue to get you started. Good luck! \n[SPACE]"

	};

	public static string[] clueOrder = new string[] {
		
		"I GREET YOU EVERY MORNING WITH CLOTHES,\n" +
		"MAKING IT EASIER TO GET READY, I SUPPOSE.\n" +
		"WHAT AM I?",

		"I EAT YOUR FOOD BEFORE YOU DO,\n" +
		"MAKING SURE YOUR YOUR BLUEBERRY PIE IS BLUE.\n" +
		"WHAT AM I?",

		"I MAY BE INANIMATE, BUT I CAN COUNT ONE AND TWO,\n" +
		"FOR I AM A PLACE WHERE YOU CAN GO POO.\n" +
		"WHAT AM I?",
		
		"I MAY LOOK SLEEK, THIN, AND COMPRESSED,\n" +
		"BUT THERE SURE IS LOTS OF INFO I PROCESS.\n" +
		"WHAT AM I?",
		
		"YOU MAY BE DONE WITH YOUR GARMENTS TODAY,\n" +
		"BUT I'M JUST GETTING STARTED SO PLEASE LET THEM STAY.\n" +
		"WHAT AM I?",

		"INFINITE STORIES FOR YOUR MIND TO BEHOLD,\n" +
		"FROM 'MOBY DICK' TO 'GOODNIGHT MOON' MY WOODEN WALLS HOLD.\n" +
		"WHAT AM I?"

	};

	public static string[] dialogOrder = new string[] {

		"Yay treasure hunt! \n[SPACE]",

		"...But what does this clue mean? \n[SPACE]",

		"There was a clue hidden in mom and dad's dresser! Hm...",

		"Dad put this clue in the oven! That's silly!",

		"There was a clue behind the toilet. I don't think I know what these words mean...",

		"Aha! I found a clue under the keyboard!",

		"I found a clue in the washing machine. Hey, I love 'Goodnight Moon'!",

		"I finally have the key! Time to go unlock my room and find the surprise!!!"

	};
}
