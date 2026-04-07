using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class DialogueLine
{
    public string characterName;
    public string dialogue;
}

public class Chapter1 : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;

    private List<DialogueLine> chapter1Lines;
    private int chapter1Index;

    void Start()
    {
        chapter1Lines = new List<DialogueLine>()
        {

//OUTSIDE THE COMPANY BUILDING
new DialogueLine(characterName = " ", dialogue = "When I got back home, my parents and friends were so excited about the news. Even my dad, who was so against the idea, finally warmed up to it."),
new DialogueLine(characterName = " ", dialogue = "And now, here I am, standing outside this building with my parents, wondering what my future will look like when I achieve my dreams. Standing here feels weird… I never thought this would happen to me."),
new DialogueLine( characterName = " ", dialogue = "I’m nervous about meeting the other girls."),
new DialogueLine( characterName = " ", dialogue = "I heard they’ve been here longer than me… that gives them an advantage. I really need to work my ass off. But for now, I’ll just try to get the hang of things."),
new DialogueLine( characterName = "Mom", dialogue = " You should call us if anything happens, okay?"),
new DialogueLine( characterName = "Dad", dialogue = " Don’t forget about your schoolwork while you're here."),
new DialogueLine( characterName = " ", dialogue = "Hearing my dad say this while holding my bags makes it feel real."),
new DialogueLine( characterName = " ", dialogue = "I roll my eyes before answering."),
new DialogueLine( characterName = "Yeonhee", dialogue = "I won't forget and I promise to call."),
new DialogueLine( characterName = "", dialogue = "After a short wait, the door swings open, and a familiar face steps out."),
new DialogueLine( characterName = "Panel member 1", dialogue = " It’s good to see you again, Yeonhee. This must be your parents, I assume?"), 
new DialogueLine( characterName = " ", dialogue = "Oh… the panel member from that day. Her smile still looks creepy. I nod."),
new DialogueLine( characterName = "Panel member 1", dialogue = " Thank you for bringing her. I’ll take over from here."),
new DialogueLine( characterName = "Dad", dialogue = " Oh? We were hoping we could just come in and."),
new DialogueLine( characterName = " ", dialogue = "The panel member cuts him off, still smiling."),
new DialogueLine( characterName = "Panel member 1", dialogue = " I’m sorry, but parents aren’t allowed in the dorms. Not allowed?"),
new DialogueLine( characterName = "Mom", dialogue = " Uhh… I guess it’s okay. You’ll be fine alone, right?"),
new DialogueLine( characterName = " ", dialogue = "I nod, unsure."),
new DialogueLine( characterName = "Yeonhee", dialogue = "Yeah… I’ll be fine."),
new DialogueLine( characterName = " ", dialogue = "I hug my parents quickly, my heart racing as I watch their car disappear."),

//COMPANY LOBBY
new DialogueLine( characterName = "Panel member 1", dialogue = " Before we proceed, I’ll need your phone."),
new DialogueLine( characterName = "Yeonhee", dialogue = "…My phone?"),
new DialogueLine( characterName = "Panel member 1", dialogue = " Personal devices aren’t permitted. You’ll be provided with an alternative."),
new DialogueLine( characterName = "Yeonhee", dialogue = "But how will I call my parents? I promised I would."),
new DialogueLine( characterName = " ", dialogue = "The panel member reaches out her hand, still smiling, without answering. This feels weird… but I guess it’s just company rules."),
new DialogueLine( characterName = " ", dialogue = "I hand over my phone."),
new DialogueLine( characterName = "Panel member 1", dialogue = " Thank you. Follow me."),
new DialogueLine( characterName = " ", dialogue = "As we walk through the hallway, I notice how quiet the company is, even though we pass training rooms."),
new DialogueLine( characterName = " ", dialogue = "We enter a large door, and behind it are different units stretching down the hall. This must be it…"),
new DialogueLine( characterName = "Panel member 1", dialogue = " This is where the other trainees live. Your unit is right down this hall."),
new DialogueLine( characterName = " ", dialogue = "The panel member fumbles through her keys. I stand behind her, listening to the chatter bleeding through the walls. Everyone is talking about training or diets… nothing fun."),
new DialogueLine( characterName = "Panel member 1", dialogue = " Got it. Here’s your unit and your key."),
new DialogueLine( characterName = "Panel member 1", dialogue = " This is where I’ll leave you. I can’t wait to bump into you again, Yeonhee."),
new DialogueLine( characterName = " ", dialogue = "We exchange smiles."),
new DialogueLine( characterName = " ", dialogue = "I look down at my keys and try the door, and it's already unlocked. I guess everyone’s home…"),

//DORM
new DialogueLine( characterName = " ", dialogue = "I step in anxiously, and before I can look around, all seven trainees greet me. As everyone introduced themselves I tried to peek through the small gaps to see what the unit looked like, but everyone was taller than me, making it harder to take a peak."),
new DialogueLine( characterName = " ", dialogue = "Geez, why is everyone in my face…"),
new DialogueLine( characterName = "Cheonmi", dialogue = " Hi, I’m Cheomni, I’m 19."),
new DialogueLine( characterName = " ", dialogue = "She looks me up and down."),
new DialogueLine( characterName = "Cheonmi", dialogue = " I hope you pick things up quickly."),
new DialogueLine( characterName = " ", dialogue = "Okay that sounds a bit rude… but she's so pretty. She actually looks like an idol already."),
new DialogueLine( characterName = "Yeonseo", dialogue = " Hi, I’m Yeonseo, I’m 23…i’ve been training here the longest but please don’t call me unnie. Also don’t mind Cheomni, she gets like that sometimes. If you need help, call me."),
new DialogueLine( characterName = "Xuan Mo", dialogue = " Hi, I’m Xuan Mo, 16… it’s nice to meet you."),
new DialogueLine( characterName = " ", dialogue = "Finally, someone my height. She’s the youngest and looks the most depressed… life hasn’t been easy for her, I guess."),
new DialogueLine( characterName = "Rose", dialogue = "Hi! I’m Rose, I’m Filipina, 20. I’ll also be a call away if you need help, with literally anything."),
new DialogueLine( characterName = " ", dialogue = "She’s way shorter than me, that's actually very rare… I’d like to be friends, she seems free spirited just like me."),
new DialogueLine( characterName = " ", dialogue = "Everyone seems nice and unique… I feel less anxious."),
new DialogueLine( characterName = "Yeonhee", dialogue = "Hi! Uh… I didn’t prepare an intro, but I’m Yeonhee, 18.. (I bow)."),
new DialogueLine( characterName = " ", dialogue = "Cheomni laughs and walks away."),
new DialogueLine( characterName = " ", dialogue = "Seems people like laughing here…"),
new DialogueLine( characterName = " ", dialogue = "Everyone else disappears into the unit, except Rose. She stares at me for a moment before speaking."),
new DialogueLine( characterName = "Rose", dialogue = " Your bags are heavy."),
new DialogueLine( characterName = " ", dialogue = "Let me help you carry them to our room"),
new DialogueLine( characterName = "Yeonhee", dialogue = "Oh… you’re my roommate?"),
new DialogueLine( characterName = " ", dialogue = "Rose smiles."),
new DialogueLine( characterName = "Rose", dialogue = " We all stay in the same room."),
new DialogueLine( characterName = "Yeonhee", dialogue = "We all share one… room?"),

//DORM ROOM
new DialogueLine( characterName = " ", dialogue = "Rose opened the door and I froze. I had never seen so many bunk beds crammed into one room before."),
new DialogueLine( characterName = " ", dialogue = "A single tiny window let in a bit of light."),
new DialogueLine( characterName = " ", dialogue = "Everyone had to share a single makeup table, which was covered in neatly labeled products."),
new DialogueLine( characterName = " ", dialogue = "Lipsticks, foundations, lotions, hair dryers, even shoes were all lined up. Somehow, despite seven people living here, the room was surprisingly tidy."),
new DialogueLine( characterName = "Rose", dialogue = " Yep, this is where we all live. You share a bunk with Xuan Mo, your bed is on top."),
new DialogueLine( characterName = "Yeonhee", dialogue = "Wow… it’s my first time seeing someone willingly choose the bottom bunk."),
new DialogueLine( characterName = "Rose", dialogue = " Hah, yeah…"),
new DialogueLine( characterName = "Rose", dialogue = " Anyways, there’s a tablet on your bed. It’s your personal tablet from the company. You can chat with the other trainees, get updates, and track your progress after every challenge."),
new DialogueLine( characterName = "Yeonhee", dialogue = "Challenges?"),
new DialogueLine( characterName = "Rose", dialogue = " I’ll explain after we check everything else."),
new DialogueLine( characterName = "Rose", dialogue = " You’ve seen the room, right?"),
new DialogueLine( characterName = "Yeonhee", dialogue = "Yeah… not much to look at."),
new DialogueLine( characterName = "Rose", dialogue = " Don’t forget this."),
new DialogueLine( characterName = " ", dialogue = "She points to a scale outside the door."),
new DialogueLine( characterName = "Yeonhee", dialogue = "A scale?"),
new DialogueLine( characterName = "Rose", dialogue = " We weigh ourselves every morning for the trainers. You can’t go over 50kg or under 45kg. They want us fit, but not sickly looking."),
new DialogueLine( characterName = "Yeonhee", dialogue = "Uh… okay?"),
new DialogueLine( characterName = " ", dialogue = "50kg for adults? I haven’t checked in years… I snack a lot…"),
new DialogueLine( characterName = "Rose", dialogue = " Let’s check your weight."),
new DialogueLine( characterName = " ", dialogue = "I step on the scale nervously."),
new DialogueLine( characterName = "Yeonhee", dialogue = "Okay…"),
new DialogueLine( characterName = " ", dialogue = "49.7kg. My heart sinks."),
new DialogueLine( characterName = "Rose", dialogue = " You’re treading on thin ice already… keep your weight in check. This is strict… I knew K-pop companies checked weight, but not like this…"),

//DORM KITCHEN
new DialogueLine( characterName = "Rose", dialogue = " Anyways this is the kitchen, we share meals here and talk…sometimes, this is the fridge we share with everyone in the unit."),
new DialogueLine( characterName = " ", dialogue = "Rose points to the bar fridge."),
new DialogueLine( characterName = "Yeonhee", dialogue = "Who’s fridge is this?"),
new DialogueLine( characterName = "Rose", dialogue = " It's everyone's fridge."),
new DialogueLine( characterName = " ", dialogue = "One bar fridge?."),
new DialogueLine( characterName = " ", dialogue = "I opened it and I couldn't help but hide my shocked expression, it was empty, just a few Diet soda’s and eggs."),
new DialogueLine( characterName = " ", dialogue = "I guess my snacks will fit."),
new DialogueLine( characterName = " ", dialogue = "I pull out snacks my mom packed. Rose’s face goes grey."),
new DialogueLine( characterName = " ", dialogue = "Cheomni walks over aggressively."),
new DialogueLine( characterName = "Cheonmi", dialogue = " What are you doing? You’re not putting… THAT… in there."),
new DialogueLine( characterName = "Yeonhee", dialogue = "Excuse me?"),
new DialogueLine( characterName = "Cheonmi", dialogue = " Throw it away."),
new DialogueLine( characterName = " ", dialogue = "I grip my snacks, thinking… What should I say?"),
//1. No, what’s your deal with my things anyways?
//2. My mom made these for me, so I won’t waste her food.
//3.Oh… yeah, I get it, it’s unhealthy… I’ll throw them away, sorry.

//option 1 and 2 outcome
//[OPTIONS 1 AND 2]
//[Relationship status with Xuan Mo:Grows, trainees: Neutral, Cheonmi: lowers] 

//COMPANY LOBBY
new DialogueLine(characterName = "Cheonmi", dialogue = ": Are you actually joking?"),
new DialogueLine(characterName = "Yeonhee", dialogue = "Why would I?, you can’t just tell me what-"),
new DialogueLine(characterName = " ", dialogue = "Rose laughs anxiously and pushes me away from the situation"),
new DialogueLine(characterName = "Yeonhee", dialogue = "Hey, stop pushing me."),
new DialogueLine(characterName = "Rose", dialogue = " Sorry, it’s just… I wouldn’t recommend annoying Cheomni or pressing her buttons."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Why?"),
new DialogueLine(characterName = "Rose", dialogue = " Just don’t."),
new DialogueLine(characterName = " ", dialogue = "Who is she anyways? It’s annoying how everyone treats her like a god…"),

//DANCE STUDIO
new DialogueLine(characterName = " ", dialogue = "Rose stops at a door."),
new DialogueLine(characterName = "Rose", dialogue = " You were pretty cool though, the last person to stand up to Cheomni was Xuan Mo."),
new DialogueLine(characterName = "Yeonhee", dialogue = "…and?"),
new DialogueLine(characterName = "Rose", dialogue = " Nothing happened. I’m just saying. I didn’t ask if something happened…"),
new DialogueLine(characterName = " ", dialogue = "I watch as Rose quietly opens the door and points down at another scale near the entrance."),
new DialogueLine(characterName = " ", dialogue = "Another scale? Is this for when I forget to weigh myself in the morning?"),
new DialogueLine(characterName = "Rose", dialogue = " Yeah, we have another scale. This one is for the manager to track our weight. He asks for your weight in the morning and then weighs you again."),
new DialogueLine(characterName = "Yeonhee", dialogue = "What happens if I go over the weight limit?"),
new DialogueLine(characterName = "Rose", dialogue = " You just have to go on a diet… and do a few things…"),
new DialogueLine(characterName = " ", dialogue = "What things…"),
new DialogueLine(characterName = "Rose", dialogue = " Anyways, this is the dance studio. We do all our practice here."),
new DialogueLine(characterName = " ", dialogue = "Rose takes me through the vocal studio and explains how after each practice, we have a challenge round where we all compete for points."),

//DORM
new DialogueLine(characterName = " ", dialogue = "When we get back to the dorm, she finally shows me the scoreboard she said she’d show me earlier."),
new DialogueLine(characterName = "Rose", dialogue = " To access your scoreboard at any point, just tap this icon on your tablet and the scoreboard will pop up. But after challenges, we check our scores immediately. It’s the first thing all the girls love to check after practice."),

//Score of the day:
//1.Cheomni
//2.Yeonseo
//3.Kandy
//4.Minjii
//5.Mei
//6.Xuan Mo
//7.Rose
//8.Yeonhee

new DialogueLine(characterName = " ", dialogue = "I notice that Rose, Xuan Mo, and I are all at the bottom while Cheomni is right at the top."),
new DialogueLine(characterName = " ", dialogue = "I can’t help but dissociate and stare at the scoreboard…"),
new DialogueLine(characterName = " ", dialogue = "Yeonseo taps my shoulder."),
new DialogueLine(characterName = "Yeonseo", dialogue = " If you want to reach Cheomni’s position, you’ll have to really try hard in every single thing you do."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Huh?"),
new DialogueLine(characterName = "Yeonseo", dialogue = " Nothing… you should go get changed, we’re about to have training."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Okay…"),

//DORM ROOM
new DialogueLine(characterName = " ", dialogue = "I throw myself onto the bed and try to breathe through the stuffy room."),
new DialogueLine(characterName = " ", dialogue = "That was weird… but I’ll just forget about it for now. She’s probably trying to throw me off. It’s a competition at the end of the day anyways."),
new DialogueLine(characterName = " ", dialogue = "The person I’m most curious about is Cheomni. I hope I didn’t get on her bad side, but she was honestly doing the most."),
new DialogueLine(characterName = " ", dialogue = "Rose seems pretty cool too, the fact that she showed me around is nice. And Xuan Mo… I don’t know much about her. She hasn’t spoken another word since she introduced herself."),
new DialogueLine(characterName = " ", dialogue = "The company seems strict, and the living conditions are a bit uncomfortable. I wish I could talk to my mom right now, but I guess I have to be strong."),
new DialogueLine(characterName = " ", dialogue = "Cheomni walks into the room, looks up at me, and sighs. She grabs her shoes and leaves.I get up and notice the dorm is quieter. Rose swings the door open quickly."),
new DialogueLine(characterName = "Rose", dialogue = " You’re going to be late for practice. Didn’t Cheomni come in and call you? Come on. put on your shoes. We have lyrical practice."),
new DialogueLine(characterName = "Yeonhee", dialogue = "No, she didn’t. I’ll be down now."),
new DialogueLine(characterName = " ", dialogue = "She literally walked in and didn’t tell me about practice… I guess the only people I can depend on are Rose and possibly Yeonseo."),

//PRACTICE ROOM
new DialogueLine(characterName = " ", dialogue = "When we arrive, the manager stands at the door with a piece of paper. He’s a tall, tanned man in an all-black suit."),
new DialogueLine(characterName = " ", dialogue = "His stare creeps me out."),
new DialogueLine(characterName = " ", dialogue = "I peek inside and see the trainer with his feet propped on the table. I breathed a sigh of relief…"),
new DialogueLine(characterName = " ", dialogue = "He seems to be more relaxed than the manager."),
new DialogueLine(characterName = "Manager", dialogue = " I hope you’re all well rested and ready for practice. We’ve decided to add another scale at the vocal practice room. Don’t ask me why, I really tried to convince them otherwise girls, they just wouldn't budge."),
new DialogueLine(characterName = " ", dialogue = "He smiles, but something tells me that’s a lie."),
new DialogueLine(characterName = " ", dialogue = "Xuan Mo scratches her neck anxiously. The manager notices and looks straight at her."),
new DialogueLine(characterName = "Manager", dialogue = " Xuan Mo, let’s start with you. What is your weight?"),
new DialogueLine(characterName = "Xuan Mo", dialogue = " Uhh… 44.9 kg."),
new DialogueLine(characterName = " ", dialogue = "Rose whispers under her breath: Still underweight."),
new DialogueLine(characterName = " ", dialogue = "She steps on the scale, and it goes to 43 kg. The manager’s face changes immediately."),
new DialogueLine(characterName = "Manager", dialogue = " You lied, Xuan Mo. When will you get your weight up? Fix this by next practice. Today I’ll excuse you because we have a new trainee."),
new DialogueLine(characterName = " ", dialogue = "Xuan Mo shakes past him. I watch as each girl walks in, anxiety written all over their faces. Cheomni is the only one looking confident."),
new DialogueLine(characterName = " ", dialogue = "When it’s finally my turn, I get cold feet."),
new DialogueLine(characterName = "Manager", dialogue = " Hi Yeonhee, I’m so upset these are our introductions… but this is my job, you understand right…"),
new DialogueLine(characterName = " ", dialogue = "I nod anxiously"),
new DialogueLine(characterName = "Manager", dialogue = " What is your weight?"),
new DialogueLine(characterName = " ", dialogue = "Shoot… what was it again, dammit I forgot… be confident, be confident, be confident."),
new DialogueLine(characterName = "Yeonhee", dialogue = "49.7 kg"),
new DialogueLine(characterName = " ", dialogue = "Yes I remembered."),
new DialogueLine(characterName = "Manager", dialogue = " Hmmmm"),
new DialogueLine(characterName = " ", dialogue = "I step on the scale. The number drops by one… 49. 6 kg. I feel his glare pierce through me."),
new DialogueLine(characterName = "Manager", dialogue = " One point wrong… and you need to start a diet."),
new DialogueLine(characterName = " ", dialogue = "I walk past him shaky. That was the most intense feeling I’ve had in a long time… not even my school exams stressed me this bad."),
new DialogueLine(characterName = "Trainer", dialogue = " Welcome back girls, and Yeonhee, I hope you’ve settled in well. Today we’re going to memorize lyrics. As you know, when you perform, we expect you to remember all your parts, even if you’re lip-syncing. Memorizing the lyrics makes it look realistic."),
new DialogueLine(characterName = " ", dialogue = "I’ll play the lyrics a few times, and each of you will have to memorize them. I may test you now or later this week, so hold onto that thought."),
new DialogueLine(characterName = " ", dialogue = "Cheomni leans in and whispers in my ear."),
new DialogueLine(characterName = "Cheonmi", dialogue = " Trainers usually say this when they’ll give you the material to practice at home. I feel like they’re going easy because of you."),
new DialogueLine(characterName = "Trainer", dialogue = " Yeonhee! No chatter. Don’t be a troublemaker just because you’re new. All the other trainees stare at me."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Sorry, it won’t happen again…"),
new DialogueLine(characterName = " ", dialogue = "Why did he scold me when it wasn’t even my fault?"),
new DialogueLine(characterName = "Trainer", dialogue = " Today we’ll sing a new song so nobody has an advantage over Yeonhee. This song has been in progress. We’re going in the direction of cute girl krush concepts today. When you sing it back, try to sound cute… more aegyo."),
new DialogueLine(characterName = " ", dialogue = "Cute? Girl krush? Are you joking?"),
new DialogueLine(characterName = "Trainer", dialogue = " Pay attention to the lyrics. We’ll play the songs twice today. The trainer glaring at me."),
new DialogueLine(characterName = " ", dialogue = "I immediately tense up."),
new DialogueLine(characterName = "Cheonmi", dialogue = " Wow… generous. She says out loud."),

//Practice starts
//Lyrics:
//Don’t be afraid
//To depend on me
//Don’t be afraid to show me love
//I want to be in your arms
//Forever and always
//don’t break my heart
//Don’t be afraid
//Tuu tuuu tuuu tuuu
//Don’t be afraid
//Tuu Tuu
//Show me love
//Tuu tuu tuuu
//Don’t be afraid to call on me
//Whenever you need
//Boy
//Tuu tuu tuuu
//Oh boy
//Tuu tuu tuuu

//option 3 outcome
//[OPTION 3]
//[Relationship status trainees: Neutral, Cheonmi: grows] 

//COMPANY LOBBY
new DialogueLine(characterName = "Cheonmi", dialogue = ": Great. Don’t bring that around again."),
new DialogueLine(characterName = " ", dialogue = "My face instantly changed, despite me agreeing, I couldn’t help but get annoyed."),
new DialogueLine(characterName = " ", dialogue = "Rose laughs nervously and pushes me away from the situation."),
new DialogueLine(characterName = "Yeonhee", dialogue = " Hey, stop pushing me."),
new DialogueLine(characterName = "Rose", dialogue = " Sorry, it’s just… I wouldn’t recommend annoying Cheomni or pressing her buttons again."),
new DialogueLine(characterName = "Rose", dialogue = " It’s a good thing you were able to calm down the situation."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Why?"),
new DialogueLine(characterName = "Rose", dialogue = " Just don’t do it again."),
new DialogueLine(characterName = " ", dialogue = "Who is she anyway? It’s annoying that everyone treats her like a god. I only agreed not to start anything because I didn’t want conflict on my first day."),

//DANCE STUDIO
new DialogueLine(characterName = " ", dialogue = "Rose stops at a door."),
new DialogueLine(characterName = "Rose", dialogue = " The only person who has stood up to Cheomni was Xuan Mo."),
new DialogueLine(characterName = "Yeonhee", dialogue = "…and?"),
new DialogueLine(characterName = "Rose", dialogue = " Nothing happened. I’m just saying."),
new DialogueLine(characterName = " ", dialogue = "I never asked if anything happened…"),
new DialogueLine(characterName = " ", dialogue = "I watch as Rose quietly opens the door and points down at another scale at the entrance."),
new DialogueLine(characterName = " ", dialogue = "Another scale? Is this for when I forget to weigh myself in the morning?"),
new DialogueLine(characterName = "Rose", dialogue = " Yeah, we have another scale. This one is for the manager to track our weight. He asks for your weight in the morning and then weighs you again."),
new DialogueLine(characterName = "Yeonhee", dialogue = "What happens if I go over the weight limit?"),
new DialogueLine(characterName = "Rose", dialogue = " You just have to go on a diet… and do a few things…"),
new DialogueLine(characterName = " ", dialogue = "What things…"),
new DialogueLine(characterName = "Rose", dialogue = " Anyways, this is the dance studio. We do all our practice here."),
new DialogueLine(characterName = " ", dialogue = "Rose takes me through the vocal studio and explains that after each practice we have a challenge round where everyone competes for points to impress the managers and recruiters."),

//DORM
new DialogueLine(characterName = " ", dialogue = "When we get back to the dorm, she finally shows me the scoreboard she said she’d show me earlier."),
new DialogueLine(characterName = "Rose", dialogue = " To access your scoreboard at any point, just tap this icon on your tablet and the scoreboard will pop up. But after challenges, we check our scores immediately. It’s the first thing all the girls love to check after practice."),
new DialogueLine(characterName = " ", dialogue = "I notice that Rose, Xuan Mo, and I are all at the bottom while Cheomni is right at the top."),

//Score of the day:
//1.Cheomni
//2.Yeonseo
//3.Kandy
//4.Minjii
//5.Mei
//6.Xuan Mo
//7.Rose
//8.Yeonhee

new DialogueLine(characterName = " ", dialogue = "I can’t help but dissociate and stare at the scoreboard…"),
new DialogueLine(characterName = " ", dialogue = "Yeonseo taps me."),
new DialogueLine(characterName = "Yeonseo", dialogue = " If you want to reach Cheomni’s position, you’ll have to really try hard in everything you do."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Huh?"),
new DialogueLine(characterName = "Yeonseo", dialogue = " Nothing… you should go get changed, we’re about to have training."),
new DialogueLine(characterName = "Yeonhee", dialogue = " Okay… "),

//DORM ROOM
new DialogueLine(characterName = " ", dialogue = "I throw myself onto the bed and try to breathe in the stuffy room."),
new DialogueLine(characterName = " ", dialogue = "That was weird… but I’ll just forget about it for now. She’s probably trying to throw me off. It’s a competition at the end of the day anyways."),
new DialogueLine(characterName = " ", dialogue = "The person I’m most curious about is Cheomni. I hope I was actually able to calm down the situation., but she was honestly doing the most."),
new DialogueLine(characterName = " ", dialogue = "Rose seems pretty cool too, the fact that she showed me around is nice. And Xuan Mo… I don’t know much about her. She hasn’t spoken another word since she introduced herself."),
new DialogueLine(characterName = " ", dialogue = "The company seems strict, and the living conditions are a bit uncomfortable. I wish I could talk to my mom right now, but I guess I have to be strong."),
new DialogueLine(characterName = " ", dialogue = "Cheomni walks into the room, looks up at me, and sighs."),
new DialogueLine(characterName = "Cheonmi", dialogue = " Don’t rest yet. We have practice right now."),
new DialogueLine(characterName = "Yeonhee", dialogue = " Really? Thank you for telling me."),
new DialogueLine(characterName = " ", dialogue = "Cheomni smiles and grabs her shoes."),
new DialogueLine(characterName = " ", dialogue = "A few seconds later, Rose walks in."),
new DialogueLine(characterName = "Rose", dialogue = " Oh, you’re already dressed. Did Cheomni just come in and call you?"),
new DialogueLine(characterName = "Yeonhee", dialogue = " Yeah, she did."),
new DialogueLine(characterName = "Rose", dialogue = " Oh… okay, let’s go."),
new DialogueLine(characterName = " ", dialogue = "Why does she look confused? I guess Cheomni doesn’t do this often… lucky me. It seems I have a lot of people I can depend on."),

//PRACTICE ROOM
new DialogueLine(characterName = " ", dialogue = "When we arrive, the manager stands at the door with a piece of paper. He’s a tall, tanned man in an all-black suit."),
new DialogueLine(characterName = " ", dialogue = "His stare creeps me out."),
new DialogueLine(characterName = " ", dialogue = "I peek inside and see the trainer with his feet propped on the table. I breathed a sigh of relief…"),
new DialogueLine(characterName = " ", dialogue = "He seems to be more relaxed than the manager."),
new DialogueLine(characterName = "Manager", dialogue = " I hope you’re all well rested and ready for practice. We’ve decided to add another scale at the vocal practice room. Don’t ask me why, I really tried to convince them otherwise girls, they just wouldn't budge."),
new DialogueLine(characterName = " ", dialogue = "He smiles, but something tells me that’s a lie."),
new DialogueLine(characterName = " ", dialogue = "Xuan Mo scratches her neck anxiously. The manager notices and looks straight at her."),
new DialogueLine(characterName = "Manager", dialogue = " Xuan Mo, let’s start with you. What is your weight?"),
new DialogueLine(characterName = "Xuan Mo", dialogue = " Uhh… 44.9 kg."),
new DialogueLine(characterName = " ", dialogue = "Rose whispers under her breath: Still underweight."),
new DialogueLine(characterName = " ", dialogue = "She steps on the scale, and it goes to 43 kg. The manager’s face changes immediately."),
new DialogueLine(characterName = "Manager", dialogue = " You lied, Xuan Mo. When will you get your weight up? Fix this by next practice. Today I’ll excuse you because we have a new trainee."),
new DialogueLine(characterName = " ", dialogue = "Xuan Mo shakes past him. I watch as each girl walks in, anxiety written all over their faces. Cheomni is the only one looking confident."),
new DialogueLine(characterName = " ", dialogue = "When it’s finally my turn, I get cold feet."),
new DialogueLine(characterName = "Manager", dialogue = " Hi Yeonhee, I’m so upset these are our introductions… but this is my job, you understand right…"),
new DialogueLine(characterName = " ", dialogue = "I nod anxiously"),
new DialogueLine(characterName = "Manager", dialogue = " What is your weight?"),
new DialogueLine(characterName = " ", dialogue = "Shoot… what was it again, dammit I forgot… be confident, be confident, be confident."),
new DialogueLine(characterName = "Yeonhee", dialogue = "49.7 kg"),
new DialogueLine(characterName = " ", dialogue = "Yes I remembered."),
new DialogueLine(characterName = "Manager", dialogue = " Hmmmm"),
new DialogueLine(characterName = " ", dialogue = "I step on the scale. The number drops by one… 49. 6 kg. I feel his glare pierce through me."),
new DialogueLine(characterName = "Manager", dialogue = " One point wrong… and you need to start a diet."),
new DialogueLine(characterName = " ", dialogue = "I walk past him shaky. That was the most intense feeling I’ve had in a long time… not even my school exams stressed me this bad."),
new DialogueLine(characterName = "Trainee", dialogue = " Welcome back girls, and Yeonhee, I hope you’ve settled in well. Today we’re going to memorize lyrics. As you know, when you perform, we expect you to remember all your parts, even if you’re lip-syncing. Memorizing the lyrics makes it look realistic."),
new DialogueLine(characterName = " ", dialogue = "I’ll play the lyrics a few times, and each of you will have to memorize them. I may test you now or later this week, so hold onto that thought."),
new DialogueLine(characterName = " ", dialogue = "Cheomni leans in and whispers in my ear."),
new DialogueLine(characterName = "Cheonmi", dialogue = " Trainers usually say this when they expect you to pick things up quickly."),
new DialogueLine(characterName = "Trainer", dialogue = " Yeonhee! No chatter. Don’t be a troublemaker just because you're new."),
new DialogueLine(characterName = " ", dialogue = "All the other trainees stare at me."),
new DialogueLine(characterName = "Cheonmi", dialogue = " It was my fault. It won’t happen again."),
new DialogueLine(characterName = "Trainer", dialogue = " Okay, I’ll let this slide since it’s not your usual behaviour."),
new DialogueLine(characterName = " ", dialogue = "Why did he only scold me when it wasn’t my fault? I’m just glad Cheomni stood up for me."),
new DialogueLine(characterName = "Trainer", dialogue = " Today we’ll sing a new song so nobody has an advantage over Yeonhee. This song has been in progress. We’re going in the direction of cute and girl krush concepts today. When you sing it back, try to sound cute… use more aegyo."),
new DialogueLine(characterName = " ", dialogue = "Cute? Girl krush? Are you joking?"),
new DialogueLine(characterName = "Trainer", dialogue = " Pay attention to the lyrics. We’ll play the songs twice today."),
new DialogueLine(characterName = "Cheonmi", dialogue = " Wow… generous. She says out loud."),
new DialogueLine(characterName = " ", dialogue = "The trainer winks at me."),
new DialogueLine(characterName = " ", dialogue = "I immediately get chills."),
new DialogueLine(characterName = " ", dialogue = "Weird…he was just scolding me a few seconds ago."),

//Practice starts
//Lyrics:
//Hey Boy
//Listen up boy
//I got a question for you
//Question for you
//Boy am I your girl
//Could i depend on you
//Depend on you,
//Cause you know
//Ohhh
//You know i’m a call away
//Ohhh
//So stop playing these games Ohhhh
//Hey boy x10

//Cheomni's good side branch2
//[Gained good points during the challenge]

//PRACTICE ROOM
new DialogueLine(characterName = " ", dialogue = "My heart is pounding… that was so difficult. I really need to work on my vocals. Rose sounded amazing, even though she messed up."),
new DialogueLine(characterName = " ", dialogue = "All the girls sit together on the couch while the manager and trainer talk on the other side of the room."),
new DialogueLine(characterName = " ", dialogue = "I wonder what they’re saying about me… the trainer keeps looking my way."),
new DialogueLine(characterName = " ", dialogue = "To my surprise, Cheomni is sitting alone on the other side of the room. She looks at me and smiles."),
new DialogueLine(characterName = " ", dialogue = "Something about that smile feels fake… it almost feels like she’s upset that I did well. But maybe I’m just overthinking it."),
new DialogueLine(characterName = " ", dialogue = "That challenge was intense. What made the situation worse was the trainer yelling at everyone… he’s not as chill as I thought he’d be."),
new DialogueLine(characterName = " ", dialogue = "I feel really bad for Xuan Mo though… he wouldn’t get off her back. Maybe I should check on her."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Hey Xuan Mo, are you okay? You’re sweating a lot."),
new DialogueLine(characterName = " ", dialogue = "Xuan Mo looks at me and sighs."),
new DialogueLine(characterName = "Xuan Mo", dialogue = " I’m fine."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Okay… I was just worried. You seem a bit out of it right now."),
new DialogueLine(characterName = "Xuan Mo", dialogue = " You should worry about yourself here."),
new DialogueLine(characterName = " ", dialogue = "Well damn… I guess this is why nobody talks to her. She makes it really difficult… but I’ll still try."),
new DialogueLine(characterName = "Cheonmi", dialogue = " Leave her. She’s always like this. Don’t waste your precious breath. The room goes quiet."),
new DialogueLine(characterName = "Cheonmi", dialogue = " Today your performance was quite good for a newbie. She smiles."),
new DialogueLine(characterName = " ", dialogue = "That didn’t feel like a compliment…"),
new DialogueLine(characterName = "Yeonhee", dialogue = "Haahh…Thank you."),
new DialogueLine(characterName = "Manager", dialogue = " So much chatter today. I see Yeonhee is quite the talker."),
new DialogueLine(characterName = " ", dialogue = "Again… Why is it always me?"),
new DialogueLine(characterName = " ", dialogue = "At least he broke the silence…"),
new DialogueLine(characterName = "Yeonhee", dialogue = "Sorry…"),
new DialogueLine(characterName = "Trainer", dialogue = " Let’s discuss today’s session. It seems we’ve been too soft on some of you… to the point where a newbie surpasses you on her first try. Ridiculous."),
new DialogueLine(characterName = " ", dialogue = "The room goes tense."),
new DialogueLine(characterName = "Trainer", dialogue = " Yeonhee, your voice… work on it. It sounds childish. I asked for cute, not toddler."),
new DialogueLine(characterName = " ", dialogue = "Wow… okay."),
new DialogueLine(characterName = "Trainer", dialogue = " Xuan Mo, forgetting lyrics again. Have you even been attending your language classes ? Your Korean sounds choppy."),
new DialogueLine(characterName = " ", dialogue = "Xuan Mo keeps the same expressionless look she does all the time."),
new DialogueLine(characterName = "Trainer", dialogue = " Rose, your voice is too powerful. If you want to be a solo artist, then leave. Stop trying to outshine everyone. At least your Korean is understandable."),
new DialogueLine(characterName = " ", dialogue = "Rose looks down quietly."),
new DialogueLine(characterName = "Trainer", dialogue = " Yeonseo, you were good. Just fix the voice cracks."),
new DialogueLine(characterName = "Yeonseo", dialogue = " Thank you, sir!"),
new DialogueLine(characterName = " ", dialogue = "The trainer pauses, then looks at Cheomni."),
new DialogueLine(characterName = " ", dialogue = "I feel nervous for her… she made the most mistakes."),
new DialogueLine(characterName = "Trainer", dialogue = " Cheomni, perfect as always. Just work on remembering your lyrics without stuttering."),
new DialogueLine(characterName = " ", dialogue = "What? That’s not fair… she messed up the most."),
new DialogueLine(characterName = "Trainer", dialogue = " Evaluations are over. Fix what I told you. I don’t want to hear these mistakes again."),
new DialogueLine(characterName = " ", dialogue = "He leaves."),
new DialogueLine(characterName = " ", dialogue = "The room finally feels lighter."),
new DialogueLine(characterName = "Manager", dialogue = " Good job, girls. We just need more practice. See you tomorrow. He looks calm… but I can literally see a vein popping on his forehead. What's wrong with him?"),

//COMPANY LOBBY
new DialogueLine(characterName = " ", dialogue = "We all start heading back to the dorm."),
new DialogueLine(characterName = "Rose", dialogue = " Well… I guess we’re sleeping early today."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Why?"),
new DialogueLine(characterName = "Yeonseo", dialogue = " You’ll see.”"),
new DialogueLine(characterName = " ", dialogue = "Hmmmm"),
new DialogueLine(characterName = " ", dialogue = "I can’t stop thinking about Rose’s voice… I barely even hear the conversation."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Uh… Rose… I think you have a really beautiful voice. I want to sing like you someday."),
new DialogueLine(characterName = " ", dialogue = "Rose smiles softly, but before she can reply"),
new DialogueLine(characterName = "Cheonmi", dialogue = " Your opinion doesn’t really matter here. If you want to succeed, listen to the trainers… not Rose"),
new DialogueLine(characterName = "Yeonseo", dialogue = " I guess that didn’t work out for you today though."),
new DialogueLine(characterName = " ", dialogue = "Cheomni’s expression tightens, but she says nothing and walks ahead. There’s so much tension here…"),

//DORM
new DialogueLine(characterName = " ", dialogue = "Back at the dorm, everyone gathers around to check their scoreboards."),
new DialogueLine(characterName = " ", dialogue = "My score went up… I’m actually close to passing Xuan Mo. On my first day… that’s insane."),

//Score of the day:
//1.Cheomni
//2.Yeonseo
//3.Kandy
//4.Minji
//5.Rose
//6.Xuan Mo
//7.Yeonhee
//8.Mei

new DialogueLine(characterName = "Rose", dialogue = " Wow, you moved up already… congrats."),
new DialogueLine(characterName = " ", dialogue = "She smiles, but she looks worried."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Thank you!"),
new DialogueLine(characterName = " ", dialogue = "I’m actually really proud of myself today… even if my evaluation was bad. I can’t wait to see what tomorrow brings."),
new DialogueLine(characterName = " ", dialogue = "But first… I need food. I’m starving."),

//DORM KITCHEN
new DialogueLine(characterName = " ", dialogue = "I walk into the kitchen."),
new DialogueLine(characterName = " ", dialogue = "Nothing."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Uh… when do we eat?"),
new DialogueLine(characterName = "Cheonmi", dialogue = " We didn’t do well today."),
new DialogueLine(characterName = "Yeonhee", dialogue = "What does that have to do with anything?"),
new DialogueLine(characterName = "Yeonseo", dialogue = " It means the manager doesn’t get us dinner."),
new DialogueLine(characterName = " ", dialogue = "What? That’s insane. Xuan Mo looks like she’s about to pass out… everyone worked so hard. And they choose to punish us with food?"),
new DialogueLine(characterName = "Yeonhee", dialogue = "How is that allowed?"),
new DialogueLine(characterName = "Xuan Mo", dialogue = " it’s allowed, they wrote it in the contract."),
new DialogueLine(characterName = " ", dialogue = "oh…I didn’t read that"),
new DialogueLine(characterName = "Yeonseo", dialogue = " You shouldn’t have thrown your snacks away. We would’ve had something to eat."),
new DialogueLine(characterName = " ", dialogue = "I knew I shouldn't have done that."),
new DialogueLine(characterName = "Cheonmi", dialogue = " We’ll survive without food. We always do."),
new DialogueLine(characterName = " ", dialogue = "Always…?"),
new DialogueLine(characterName = "Cheonmi", dialogue = " Don’t worry, Yeonhee. You’ll adapt soon."),
new DialogueLine(characterName = " ", dialogue = "She smiles again."),
new DialogueLine(characterName = " ", dialogue = "This time… it doesn’t feel comforting at all."),
new DialogueLine(characterName = " ", dialogue = "I guess this really is my life now… I need to work harder."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Okay then."),
new DialogueLine(characterName = " ", dialogue = "Yeonseo rolls her eyes and heads to bed. Everyone else slowly disappears. I follow behind her."),

//DORM ROOM
new DialogueLine(characterName = " ", dialogue = "The least I can do is sleep through the hunger."),
new DialogueLine(characterName = " ", dialogue = "*notification from tablet*"),
new DialogueLine(characterName = "Yeonhee", dialogue = "What’s that…?"),
new DialogueLine(characterName = " ", dialogue = "I glance at the tablet."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Oh… I got a message."),
new DialogueLine(characterName = " ", dialogue = "Anonymous: Leave while you still can."),
new DialogueLine(characterName = "Yeonhee", dialogue = "“Leave while you still can”?"),
new DialogueLine(characterName = " ", dialogue = "Lol… What a childish way to scare competition. I’m going to sleep. …but what if…"),
new DialogueLine(characterName = " ", dialogue = "Ugh… never mind."),

//Cheomni's good side branch
//[Gained bad points during the challenge]

//PRACTICE ROOM
new DialogueLine(characterName = " ", dialogue = "My heart is pounding… that was so difficult."),
new DialogueLine(characterName = " ", dialogue = "I can’t believe I did that bad. I really thought I’d get the hang of it immediately."),
new DialogueLine(characterName = " ", dialogue = "Everyone sounded so good. Even with their mistakes, they still sounded amazing… and then there’s me."),
new DialogueLine(characterName = " ", dialogue = "I really need to work on my vocals. Rose sounded incredible. It was like hearing an angel sing."),
new DialogueLine(characterName = " ", dialogue = "All the girls sit together on the couch while the manager and trainer talk on the other side of the room."),
new DialogueLine(characterName = " ", dialogue = "I wonder what they’re saying about me… the trainer keeps looking my way. I hope they don’t kick me out. I wouldn’t even blame them."),
new DialogueLine(characterName = " ", dialogue = "But to my surprise, Cheomni is sitting alone on the other side of the room. She looks at me and smiles."),
new DialogueLine(characterName = " ", dialogue = "She seems genuine… but I can’t shake this embarrassment."),
new DialogueLine(characterName = " ", dialogue = "Maybe I’m just overthinking it. It is my first day after all."),
new DialogueLine(characterName = " ", dialogue = "That challenge was intense. What made it worse was the trainer yelling at everyone… he’s not as chill as I thought. Not even close."),
new DialogueLine(characterName = " ", dialogue = "I feel really bad for Xuan Mo though… he wouldn’t get off her back. Maybe I should check on her."),
new DialogueLine(characterName = "Yeonhee", dialogue = " Hey Xuan Mo, are you okay? You’re sweating a lot."),
new DialogueLine(characterName = " ", dialogue = "Xuan Mo looks at me and sighs."),
new DialogueLine(characterName = "Xuan Mo", dialogue = " I’m fine."),
new DialogueLine(characterName = "Yeonhee", dialogue = " Okay… I was just worried. You seem a bit out of it."),
new DialogueLine(characterName = "Xuan Mo", dialogue = " You should worry about yourself here."),
new DialogueLine(characterName = " ", dialogue = "Well damn… I guess this is why nobody talks to her. She makes it really difficult… but I’ll still try."),
new DialogueLine(characterName = "Cheonmi", dialogue = " Leave her. She’s always like this. Don’t waste your breath. The room goes quiet."),
new DialogueLine(characterName = "Cheonmi", dialogue = " Today your performance wasn’t bad for a newbie. You’ll get better with practice… I didn’t have it figured out when I first arrived either."),
new DialogueLine(characterName = " ", dialogue = "She smiles."),
new DialogueLine(characterName = " ", dialogue = "Okay… I need to give myself a break."),
new DialogueLine(characterName = "Yeonhee", dialogue = " Thank you… that’s actually comforting."),
new DialogueLine(characterName = "Manager", dialogue = " So much chatter coming from you, Yeonhee. You should get rid of that habit."),
new DialogueLine(characterName = " ", dialogue = "Again… Why is it always me?"),
new DialogueLine(characterName = " ", dialogue = "At least he broke the silence…"),
new DialogueLine(characterName = "Yeonhee", dialogue = " Sorry…"),
new DialogueLine(characterName = "Trainer", dialogue = " Let’s discuss today’s session. We’ve been too soft on some of you… I don’t know what happened, but today’s performance was absolutely ridiculous."),
new DialogueLine(characterName = " ", dialogue = "The room goes tense."),
new DialogueLine(characterName = "Trainer", dialogue = " Yeonhee, your voice… work on it. It sounds childish. I asked for cute, not toddler. And what’s with forgetting such a simple lyric? If you want to stay in this company… pull up your socks. I’ll make a separate schedule for you outside of training hours. You need it."),
new DialogueLine(characterName = " ", dialogue = "Wow… okay. He didn’t have to be that harsh."),
new DialogueLine(characterName = "Trainer", dialogue = " Xuan Mo, forgetting lyrics again. Have you even been attending your language classes? Your Korean sounds choppy."),
new DialogueLine(characterName = " ", dialogue = "Xuan Mo keeps the same expressionless look."),
new DialogueLine(characterName = "Trainer", dialogue = " Rose, your voice is too powerful. If you want to be a solo artist, then leave. Stop trying to outshine everyone. At least your Korean is understandable."),
new DialogueLine(characterName = " ", dialogue = "Rose looks down quietly."),
new DialogueLine(characterName = "Trainer", dialogue = " Yeonseo, you were good. Just fix the voice cracks."),
new DialogueLine(characterName = "Yeonseo", dialogue = " Thank you, sir!"),
new DialogueLine(characterName = " ", dialogue = "The trainer pauses, then looks at Cheomni."),
new DialogueLine(characterName = " ", dialogue = "I feel nervous for her… she made the most mistakes."),
new DialogueLine(characterName = "Trainer", dialogue = " Cheomni, perfect as always. Just work on remembering your lyrics without stuttering."),
new DialogueLine(characterName = " ", dialogue = "What? That’s not fair… she messed up the most. Seriously… what is she, funding the company or something?"),
new DialogueLine(characterName = "Trainer", dialogue = " Evaluations are over. Fix what I told you. I don’t want to hear these mistakes again."),
new DialogueLine(characterName = " ", dialogue = "He leaves."),
new DialogueLine(characterName = " ", dialogue = "The room finally feels lighter."),
new DialogueLine(characterName = "Manager", dialogue = " Good job, girls. We just need more practice. See you tomorrow."),
new DialogueLine(characterName = " ", dialogue = "He looks calm… but I can literally see a vein popping on his forehead. What’s wrong with him?"),

//COMPANY LOBBY
new DialogueLine(characterName = " ", dialogue = "We all start heading back to the dorm."),
new DialogueLine(characterName = "Rose", dialogue = " Well… I guess we’re sleeping early today."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Why?"),
new DialogueLine(characterName = "Yeonseo", dialogue = " You’ll see."),
new DialogueLine(characterName = " ", dialogue = "Hmm…"),
new DialogueLine(characterName = " ", dialogue = "I can’t stop thinking about Rose’s voice. I barely even hear the conversation."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Uh… Rose… I think you have a really beautiful voice. I want to sing like you someday."),
new DialogueLine(characterName = " ", dialogue = "Rose smiles softly, but before she can reply-"),
new DialogueLine(characterName = "Cheonmi", dialogue = " Your opinion doesn’t really matter here. If you want to succeed, listen to the trainers… not Rose."),
new DialogueLine(characterName = "Yeonseo", dialogue = " I guess that didn’t work out for you today though."),
new DialogueLine(characterName = "Cheonmi", dialogue = " …"),
new DialogueLine(characterName = " ", dialogue = "Her expression tightens, but she says nothing and walks ahead."),
new DialogueLine(characterName = " ", dialogue = "There’s so much tension here…"),

//DORM
new DialogueLine(characterName = " ", dialogue = "Back at the dorm, everyone gathers to check their scoreboards."),
new DialogueLine(characterName = " ", dialogue = "My score stayed the same… this is so disheartening. I really need to work harder."),

 //Score of the day:
//1.Cheomni
//2.Yeonseo
//3.Kandy
//4.Minjii
//5.Rose
//6.Mei
//7.Xuan Mo
//8.Yeonhee

new DialogueLine(characterName = " ", dialogue = "Rose moved up two tiers… just a few hours ago we were right next to each other."),
new DialogueLine(characterName = "Rose", dialogue = " Don’t worry about the scores today. You did your best."),
new DialogueLine(characterName = " ", dialogue = "That’s easy for you to say…"),
new DialogueLine(characterName = "Yeonhee", dialogue = "Thank you."),
new DialogueLine(characterName = " ", dialogue = "Despite everything… I’m actually proud of myself for making it through that challenge.”), Even if my evaluation was bad."),
new DialogueLine(characterName = " ", dialogue = "I can’t wait to see what tomorrow brings."),
new DialogueLine(characterName = " ", dialogue = "But first… I need food. I’m starving."),

//DORM KITCHEN
new DialogueLine(characterName = " ", dialogue = "I walk into the kitchen."),
new DialogueLine(characterName = " ", dialogue = "Nothing."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Uh… when do we eat?"),
new DialogueLine(characterName = "Cheonmi", dialogue = " We didn’t do well today."),
new DialogueLine(characterName = "Yeonhee", dialogue = " What does that have to do with anything?"),
new DialogueLine(characterName = "Yeonseo", dialogue = " It means the manager doesn’t get us dinner."),
new DialogueLine(characterName = " ", dialogue = "What? That’s insane. Xuan Mo looks like she’s about to pass out… everyone worked so hard… and they punish us with food?"),
new DialogueLine(characterName = "Yeonhee", dialogue = "How is that allowed?"),
new DialogueLine(characterName = "Xuan Mo", dialogue = " It’s allowed. It’s in the contract."),
new DialogueLine(characterName = " ", dialogue = "Oh… I didn’t read that."),
new DialogueLine(characterName = "Yeonseo", dialogue = " You shouldn’t have thrown your snacks away. We would’ve had something to eat."),
new DialogueLine(characterName = " ", dialogue = "I knew I shouldn’t have done that."),
new DialogueLine(characterName = "Cheonmi", dialogue = " We’ll survive without food. We always do."),
new DialogueLine(characterName = " ", dialogue = "Always…?"),
new DialogueLine(characterName = "Cheonmi", dialogue = " Don’t worry, Yeonhee. You’ll adapt soon."),
new DialogueLine(characterName = " ", dialogue = "She smiles again."),
new DialogueLine(characterName = " ", dialogue = "This time… it doesn’t feel comforting at all."),
new DialogueLine(characterName = " ", dialogue = "I guess this really is my life now… I need to work harder."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Okay then."),
new DialogueLine(characterName = " ", dialogue = "Yeonseo rolls her eyes and heads to bed."),
new DialogueLine(characterName = " ", dialogue = "Everyone else slowly disappears. I follow behind her."),

//DORM ROOM
new DialogueLine(characterName = " ", dialogue = "The least I can do is sleep through the hunger."),
new DialogueLine(characterName = " ", dialogue = "notification from tablet"),
new DialogueLine(characterName = "Yeonhee", dialogue = "What’s that…?"),
new DialogueLine(characterName = " ", dialogue = "I glance at the tablet."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Oh… I got a message."),
new DialogueLine(characterName = " ", dialogue = "Anonymous: Leave while you still can."),
new DialogueLine(characterName = "Yeonhee", dialogue = "“Leave while you still can?"),
new DialogueLine(characterName = " ", dialogue = "Lol… what a childish way to scare competition. I’m going to sleep. …but what if…"),
new DialogueLine(characterName = " ", dialogue = "Ugh… never mind."),

//Cheomni's bad side branch
//[Gained good points during the challenge]

//PRACTICE ROOM
new DialogueLine(characterName = " ", dialogue = "My heart is pounding… that was so difficult.I really need to work on my vocals.Rose sounded amazing, even though she messed up."),
new DialogueLine(characterName = " ", dialogue = "All the girls sit together on the couch while the manager and trainer talk on the other side of the room."),
new DialogueLine(characterName = " ", dialogue = "I wonder what they’re saying about me… the trainer keeps looking my way."),
new DialogueLine(characterName = " ", dialogue = "To my surprise, Cheomni is sitting alone on the other side of the room. She glances at me, then looks back at the wall."),
new DialogueLine(characterName = " ", dialogue = "Something about that glance… it almost feels like she’s upset that I did well. But maybe I’m just overthinking it."),
new DialogueLine(characterName = " ", dialogue = "That challenge was intense. What made the situation worse was the trainer yelling at everyone… he’s not as chill as I thought he’d be."),
new DialogueLine(characterName = " ", dialogue = "I feel really bad for Xuan Mo though… he wouldn’t get off her back. Maybe I should check on her."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Hey Xuan Mo, are you okay? You’re sweating a lot."),
new DialogueLine(characterName = " ", dialogue = "Xuan Mo looks at me and sighs."),
new DialogueLine(characterName = "Xuan Mo", dialogue = " I’m fine."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Okay… I was just worried. You seem a bit out of it right now."),
new DialogueLine(characterName = "Xuan Mo", dialogue = " You should worry about yourself here."),
new DialogueLine(characterName = " ", dialogue = "Well damn… I guess this is why nobody talks to her.She makes it really difficult… but I’ll still try."),
new DialogueLine(characterName = "Cheonmi", dialogue = " Leave her. She’s always like this."),
new DialogueLine(characterName = " ", dialogue = "The room goes quiet."),
new DialogueLine(characterName = " ", dialogue = "Cheomni stares at me for a moment, like she’s thinking about what to say."),
new DialogueLine(characterName = "Cheonmi", dialogue = " Your performance was questionable, but I guess it wasn’t that bad… just don’t start running to the top position now."),
new DialogueLine(characterName = " ", dialogue = "That didn’t feel like a compliment…"),
new DialogueLine(characterName = "Yeonhee", dialogue = "Haahh… thanks."),
new DialogueLine(characterName = "Manager", dialogue = " So much chatter today. I see Yeonhee is quite the talker."),
new DialogueLine(characterName = " ", dialogue = "Again… Why is it always me?"),
new DialogueLine(characterName = " ", dialogue = "At least he broke the silence…"),
new DialogueLine(characterName = "Yeonhee", dialogue = "Sorry…"),
new DialogueLine(characterName = "Trainer", dialogue = " Let’s discuss today’s session. It seems we’ve been too soft on some of you… to the point where a newbie surpasses you on her first try. Ridiculous."),
new DialogueLine(characterName = " ", dialogue = "The room goes tense."),
new DialogueLine(characterName = "Trainer", dialogue = " Yeonhee, your voice… work on it. It sounds childish. I asked for cute, not toddler."),
new DialogueLine(characterName = " ", dialogue = "Wow… okay"),
new DialogueLine(characterName = "Trainer", dialogue = " Xuan Mo, forgetting lyrics again. Have you even been attending your language classes? Your Korean sounds choppy."),
new DialogueLine(characterName = " ", dialogue = "Xuan Mo keeps that same expressionless look she always has."),
new DialogueLine(characterName = "Trainer", dialogue = " Rose, your voice is too powerful. If you want to be a solo artist, then leave. Stop trying to outshine everyone. At least your Korean is understandable."),
new DialogueLine(characterName = " ", dialogue = "Rose looks down quietly."),
new DialogueLine(characterName = "Trainer", dialogue = " Yeonseo, you were good. Just fix the voice cracks."),
new DialogueLine(characterName = "Yeonseo", dialogue = " Thank you, sir!"),
new DialogueLine(characterName = " ", dialogue = "The trainer pauses, then looks at Cheomni."),
new DialogueLine(characterName = " ", dialogue = "As bad as it sounds… I actually can’t wait for her to get scolded. She’s been on her high horse since I got here… and she made the most mistakes out of everyone."),
new DialogueLine(characterName = "Trainer", dialogue = " Cheomni, perfect as always. Just work on remembering your lyrics without stuttering."),
new DialogueLine(characterName = " ", dialogue = "What? That’s not fair… she messed up the most."),
new DialogueLine(characterName = "Trainer", dialogue = " Evaluations are over. Fix what I told you. I don’t want to hear these mistakes again."),
new DialogueLine(characterName = " ", dialogue = "He leaves."),
new DialogueLine(characterName = " ", dialogue = "The room finally feels lighter."),
new DialogueLine(characterName = "Manager", dialogue = " Good job, girls. We just need more practice. See you tomorrow."),
new DialogueLine(characterName = " ", dialogue = "He looks calm… but I can literally see a vein popping on his forehead. What’s wrong with him?"),

//COMPANY LOBBY
new DialogueLine(characterName = " ", dialogue = "We all start heading back to the dorm."),
new DialogueLine(characterName = " ", dialogue = "Rose wraps her arm around mine while Yeonseo walks beside me. It feels like we’re getting closer… It makes today feel a little less exhausting."),
new DialogueLine(characterName = "Rose", dialogue = " Well… I guess we’re sleeping early today."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Why?"),
new DialogueLine(characterName = "Yeonseo", dialogue = " You’ll see."),
new DialogueLine(characterName = " ", dialogue = "Hmm…"),
new DialogueLine(characterName = " ", dialogue = "I can’t stop thinking about Rose’s voice… I barely even hear the conversation."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Uh… Rose… I think you have a really beautiful voice. I want to sing like you someday."),
new DialogueLine(characterName = " ", dialogue = "Rose smiles softly, but before she can reply"),
new DialogueLine(characterName = "Cheonmi", dialogue = " Your opinion doesn’t really matter here. If you want to succeed, listen to the trainers… not Rose."),
new DialogueLine(characterName = "Yeonseo", dialogue = " I guess that didn’t work out for you today though."),
new DialogueLine(characterName = " ", dialogue = "Cheomni’s expression tightens, but she says nothing and walks ahead. There’s so much tension here…"),

//DORM
new DialogueLine(characterName = " ", dialogue = "Back at the dorm, everyone gathers to check their scoreboards."),
new DialogueLine(characterName = " ", dialogue = "My score went up… I’m actually close to passing Xuan Mo. On my first day… that’s insane."),

//Score of the day:
//1.Cheomni
//2.Yeonseo
//3.Karla
//4.Minji
//5.Rose
//6.Xuan Mo
//7.Yeonhee
//8.Mei

new DialogueLine(characterName = "Rose", dialogue = " Wow, you moved up already… congrats."),
new DialogueLine(characterName = " ", dialogue = "She smiles, but she looks worried."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Thank you!"),
new DialogueLine(characterName = " ", dialogue = "I’m actually really proud of myself today… even if my evaluation was bad. I can’t wait to see what tomorrow brings."),
new DialogueLine(characterName = " ", dialogue = "But first… I need food. I’m starving."),

//DORM KITCHEN
new DialogueLine(characterName = " ", dialogue = "I walk into the kitchen."),
new DialogueLine(characterName = " ", dialogue = "Nothing."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Uh… when do we eat?"),
new DialogueLine(characterName = "Cheonmi", dialogue = " We didn’t do well today."),
new DialogueLine(characterName = "Yeonhee", dialogue = "What does that have to do with anything?"),
new DialogueLine(characterName = "Yeonseo", dialogue = " It means the manager doesn’t get us dinner."),
new DialogueLine(characterName = " ", dialogue = "What? That’s insane. Xuan Mo looks like she’s about to pass out… everyone worked so hard… and they punish us with food?"),
new DialogueLine(characterName = "Yeonhee", dialogue = "How is that allowed?"),
new DialogueLine(characterName = "Xuan Mo", dialogue = " It’s allowed. It’s in the contract."),
new DialogueLine(characterName = " ", dialogue = "Oh… I didn’t read that."),
new DialogueLine(characterName = "Yeonseo", dialogue = " Yeonhee, do you still have your snacks?"),
new DialogueLine(characterName = "Yeonhee", dialogue = "Yeah, I do. We can eat that for dinner."),
new DialogueLine(characterName = " ", dialogue = "Rose and Yeonseo light up immediately."),
new DialogueLine(characterName = " ", dialogue = "Good thing I didn’t throw them away…"),
new DialogueLine(characterName = "Cheonmi", dialogue = " We’ll survive without food. We always do."),
new DialogueLine(characterName = " ", dialogue = "Always…?"),
new DialogueLine(characterName = "Cheonmi", dialogue = " I’m not eating that junk."),
new DialogueLine(characterName = "Yeonseo", dialogue = " That’s great then. More for us."),
new DialogueLine(characterName = "Xuan Mo", dialogue = " I won’t eat it either."),
new DialogueLine(characterName = "Rose", dialogue = " You need to gain weight. Did you not hear what the manager said today?"),
new DialogueLine(characterName = " ", dialogue = "The room goes tense again."),
new DialogueLine(characterName = "Yeonhee", dialogue = "My mom didn’t pack that much… we’ll share the tteokbokki and each get a bit of bibimbap."),
new DialogueLine(characterName = "Rose", dialogue = " Ouu, I’m so hungry… let’s eat."),
new DialogueLine(characterName = " ", dialogue = "Cheomni rolls her eyes and leaves for the practice room."),
new DialogueLine(characterName = " ", dialogue = "I won’t be having these snacks every day…"),
new DialogueLine(characterName = " ", dialogue = "I guess this really is my life now… I need to work harder."),
new DialogueLine(characterName = "Yeonseo", dialogue = " Hmm… this is so good. I haven’t had this kind of food in a while."),
new DialogueLine(characterName = "Xuan Mo", dialogue = " Yeah…"),
new DialogueLine(characterName = "Yeonhee", dialogue = "What do you guys usually eat?"),
new DialogueLine(characterName = " ", dialogue = "Everyone goes silent."),
new DialogueLine(characterName = " ", dialogue = "Do these people even eat…?"),
new DialogueLine(characterName = "Yeonseo", dialogue = " When you see your mom again, tell her we said thank you. Xuan Mo nods."),
new DialogueLine(characterName = "Rose", dialogue = " Yeah, it was really good… but we need to get rid of the evidence."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Why?"),
new DialogueLine(characterName = "Rose", dialogue = " He shouldn’t know we ate without his permission."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Huh?"),
new DialogueLine(characterName = "Yeonseo", dialogue = " Let’s just throw this out and go to sleep."),
new DialogueLine(characterName = " ", dialogue = "We clean everything up together. It makes me uneasy… Why do I have to hide the fact that I ate?"),
new DialogueLine(characterName = " ", dialogue = "After that, Rose and Xuan Mo head to the gym to burn it off… which is honestly kind of crazy."),
new DialogueLine(characterName = " ", dialogue = "Yeonseo goes straight to bed. I follow."),

//DORM ROOM
new DialogueLine(characterName = " ", dialogue = "notification from tablet"),
new DialogueLine(characterName = "Yeonhee", dialogue = "What’s that…?"),
new DialogueLine(characterName = " ", dialogue = "I glance at the tablet"),
new DialogueLine(characterName = "Yeonhee", dialogue = "Oh… I got a message."),
new DialogueLine(characterName = " ", dialogue = "Anonymous: Leave while you still can."),
new DialogueLine(characterName = "Yeonhee", dialogue = "“Leave while you still can?"),
new DialogueLine(characterName = " ", dialogue = "Lol… What a childish way to scare competition. I’m going to sleep. …but what if…"),
new DialogueLine(characterName = " ", dialogue = "Ugh… never mind."),

//Cheomni's bad side branch2
//[Gained bad points during the challenge]

//PRACTICE ROOM
new DialogueLine(characterName = " ", dialogue = "My heart is pounding… that was so difficult."),
new DialogueLine(characterName = " ", dialogue = "I can’t believe I did so terribly, I really thought I would get the hang of it immediately. Everyone sounded so good, even with their mistakes… and then you get me."),
new DialogueLine(characterName = " ", dialogue = "I really need to work on my vocals. Rose sounded amazing, it was like hearing an angel sing."),
new DialogueLine(characterName = " ", dialogue = "All the girls sit together on the couch while the manager and trainer talk on the other side of the room."),
new DialogueLine(characterName = " ", dialogue = "I wonder what they’re saying about me… the trainer keeps looking my way. I hope they don’t kick me out, I wouldn’t blame them if they did."),
new DialogueLine(characterName = " ", dialogue = "But to my surprise, Cheomni is sitting alone on the other side of the room. She glances at me, then looks back at the wall."),
new DialogueLine(characterName = " ", dialogue = "Something about that glance… It makes me feel uncomfortable. But maybe I’m just overthinking it."),
new DialogueLine(characterName = " ", dialogue = "That challenge was intense. What made the situation worse was the trainer yelling at everyone… he’s not as chill as I thought he’d be."),
new DialogueLine(characterName = " ", dialogue = "I feel really bad for Xuan Mo though… he wouldn’t get off her back. Maybe I should check on her."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Hey Xuan Mo, are you okay? You’re sweating a lot."),
new DialogueLine(characterName = " ", dialogue = "Xuan Mo looks at me and sighs."),
new DialogueLine(characterName = "Xuan Mo", dialogue = " I’m fine."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Okay… I was just worried. You seem a bit out of it right now."),
new DialogueLine(characterName = "Xuan Mo", dialogue = " You should worry about yourself here."),
new DialogueLine(characterName = " ", dialogue = "Well damn… I guess this is why nobody talks to her. She makes it really difficult… but I’ll still try."),
new DialogueLine(characterName = "Cheonmi", dialogue = " Leave her. She’s always like this."),
new DialogueLine(characterName = " ", dialogue = "The room goes quiet."),
new DialogueLine(characterName = " ", dialogue = "Cheomni stares at me before speaking, like she’s choosing her words."),
new DialogueLine(characterName = "Cheonmi", dialogue = " Your performance was questionable, but I guess it wasn’t that bad… That didn’t feel like a compliment…"),
new DialogueLine(characterName = "Yeonhee", dialogue = "Haahh… thanks."),
new DialogueLine(characterName = "Manager", dialogue = " So much chatter coming from you, Yeonhee. You should get rid of that habit."),
new DialogueLine(characterName = " ", dialogue = "Again… Why is it always me?"),
new DialogueLine(characterName = " ", dialogue = "At least he broke the silence…"),
new DialogueLine(characterName = "Yeonhee", dialogue = "Sorry…"),
new DialogueLine(characterName = "Trainer", dialogue = " Let’s discuss today’s session. It seems we’ve been too soft on some of you… I don’t know what happened, but today’s performance was absolutely ridiculous."),
new DialogueLine(characterName = " ", dialogue = "The room goes tense."),
new DialogueLine(characterName = "Trainer", dialogue = " Yeonhee, your voice… work on it. It sounds childish. I asked for cute, not toddler. And what’s up with you forgetting a simple lyric? If you want to continue in this company, pull up your socks. I don’t want to talk about this ridiculous performance next time. I’ll create a separate schedule for you to practice outside of training hours. You need it."),
new DialogueLine(characterName = " ", dialogue = "Cheomni laughs softly."),
new DialogueLine(characterName = " ", dialogue = "What’s her deal anyway?"),
new DialogueLine(characterName = " ", dialogue = "This is actually so embarrassing… he didn’t have to be that harsh."),
new DialogueLine(characterName = "Trainer", dialogue = " Xuan Mo, forgetting lyrics again. Have you even been attending your language classes? Your Korean sounds choppy."),
new DialogueLine(characterName = " ", dialogue = "Xuan Mo keeps the same expressionless look she always has."),
new DialogueLine(characterName = "Trainer", dialogue = " Rose, your voice is too powerful. If you want to be a solo artist, then leave. Stop trying to outshine everyone. At least your Korean is understandable."),
new DialogueLine(characterName = " ", dialogue = "Rose looks down quietly."),
new DialogueLine(characterName = "Trainer", dialogue = " Yeonseo, you were good. Just fix the voice cracks."),
new DialogueLine(characterName = "Yeonseo", dialogue = " Thank you, sir!"),
new DialogueLine(characterName = " ", dialogue = "The trainer pauses, then looks at Cheomni."),
new DialogueLine(characterName = " ", dialogue = "As bad as it sounds, I actually can’t wait for her to get scolded. She’s been on her high horse since I got here… and she made the most mistakes out of everyone."),
new DialogueLine(characterName = "Trainer", dialogue = " Cheomni, perfect as always. Just work on remembering your lyrics without stuttering."),
new DialogueLine(characterName = " ", dialogue = "What? That’s not fair… she messed up the most."),
new DialogueLine(characterName = "Trainer", dialogue = " Evaluations are over. Fix what I told you. I don’t want to hear these mistakes again."),
new DialogueLine(characterName = " ", dialogue = "He leaves."),
new DialogueLine(characterName = " ", dialogue = "The room finally feels lighter."),
new DialogueLine(characterName = "Manager", dialogue = " Good job, girls. We just need more practice. See you tomorrow."),
new DialogueLine(characterName = " ", dialogue = "He looks calm… but I can literally see a vein popping on his forehead. What’s wrong with him?"),

//COMPANY LOBBY
new DialogueLine(characterName = " ", dialogue = "We all start heading back to the dorm."),
new DialogueLine(characterName = " ", dialogue = "Rose wraps her arm around mine while Yeonseo walks beside me. It feels like we’re forming a closer bond… It makes today feel a little less torturous."),
new DialogueLine(characterName = "Rose", dialogue = " Well… I guess we’re sleeping early today."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Why?"),
new DialogueLine(characterName = "Yeonseo", dialogue = " You’ll see."),
new DialogueLine(characterName = " ", dialogue = "I can’t stop thinking about Rose’s voice… I barely even hear the conversation."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Uh… Rose… I think you have a really beautiful voice. I want to sing like you someday."),
new DialogueLine(characterName = " ", dialogue = "Rose smiles softly, but before she can reply"),
new DialogueLine(characterName = "Cheonmi", dialogue = " Your opinion doesn’t really matter here. If you want to succeed, listen to the trainers… not Rose."),
new DialogueLine(characterName = "Yeonseo", dialogue = " I guess that didn’t work out for you today though."),
new DialogueLine(characterName = " ", dialogue = "Cheomni’s expression tightens, but she says nothing and walks ahead. There’s so much tension here…"),

//DORM
new DialogueLine(characterName = " ", dialogue = "Back at the dorm, everyone gathers around to check their scoreboards."),

//Score of the day:
//1.Cheomni
//2.Yeonseo
//3.Kandy
//4.Minjii
//5.Rose
//6.Mei
//7.Xuan Mo
//8.Yeonhee

new DialogueLine(characterName = " ", dialogue = "My score remained the same… this is so disheartening. I really need to work harder. Rose moved up two tiers. Just a few hours ago we were right next to each other."),
new DialogueLine(characterName = "Rose", dialogue = " Don’t worry about the scores today, you did your best."),
new DialogueLine(characterName = " ", dialogue = "That’s easy for you to say…"),
new DialogueLine(characterName = "Yeonhee", dialogue = "Thank you."),
new DialogueLine(characterName = " ", dialogue = "Despite everything, I’m actually proud of myself for making it through the challenge… even if my evaluation was bad. I can’t wait to see what tomorrow brings."),
new DialogueLine(characterName = " ", dialogue = "But first… I need food. I’m starving."),

//DORM KITCHEN
new DialogueLine(characterName = " ", dialogue = "I walk into the kitchen."),
new DialogueLine(characterName = " ", dialogue = "Nothing."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Uh… when do we eat?"),
new DialogueLine(characterName = "Cheonmi", dialogue = " We didn’t do well today."),
new DialogueLine(characterName = "Yeonhee", dialogue = "What does that have to do with anything?"),
new DialogueLine(characterName = "Yeonseo", dialogue = " It means the manager doesn’t get us dinner."),
new DialogueLine(characterName = " ", dialogue = "What ? That’s insane.Xuan Mo looks like she’s about to pass out… everyone worked so hard, and they punish us with food?"),
new DialogueLine(characterName = "Yeonhee", dialogue = "How is that allowed?"),
new DialogueLine(characterName = "Xuan Mo", dialogue = " It’s allowed. They wrote it in the contract."),
new DialogueLine(characterName = " ", dialogue = "Oh… I didn’t read that."),
new DialogueLine(characterName = "Yeonseo", dialogue = " Yeonhee, do you still have your snacks?"),
new DialogueLine(characterName = "Yeonhee", dialogue = "Yeah, I do. We can eat that for dinner."),
new DialogueLine(characterName = " ", dialogue = "Rose and Yeonseo light up."),
new DialogueLine(characterName = " ", dialogue = "Now imagine if I threw my snacks away."),
new DialogueLine(characterName = "Cheonmi", dialogue = " We’ll survive without food. We always do."),
new DialogueLine(characterName = " ", dialogue = "Always…?"),
new DialogueLine(characterName = "Cheonmi", dialogue = " I’m not eating that junk."),
new DialogueLine(characterName = "Yeonseo", dialogue = " That’s great then, more for us."),
new DialogueLine(characterName = "Xuan Mo", dialogue = " I won’t eat it either."),
new DialogueLine(characterName = "Rose", dialogue = " You need to gain weight. Did you not hear what the manager said today? The room goes tense again."),
new DialogueLine(characterName = "Yeonhee", dialogue = "My mom didn’t pack that much… we’ll just share the tteokbokki and have one bibimbap each."),
new DialogueLine(characterName = "Rose", dialogue = " Ouu, I’m so hungry… let’s eat."),
new DialogueLine(characterName = " ", dialogue = "Cheomni rolls her eyes and goes back to bed."),
new DialogueLine(characterName = " ", dialogue = "I won’t be having these snacks every day."),
new DialogueLine(characterName = " ", dialogue = "I guess this really is my life now… I need to work harder."),
new DialogueLine(characterName = "Yeonseo", dialogue = " This is actually so good… I haven’t had food like this in a while."),
new DialogueLine(characterName = "Xuan Mo", dialogue = " Yeah…"),
new DialogueLine(characterName = "Yeonhee", dialogue = "What do you guys usually eat?"),
new DialogueLine(characterName = " ", dialogue = "Everyone goes silent."),
new DialogueLine(characterName = " ", dialogue = "Do these people even eat?"),
new DialogueLine(characterName = "Yeonseo", dialogue = " When you see your mom again, tell her we said thank you for the snacks. Xuan Mo nods."),
new DialogueLine(characterName = "Rose", dialogue = " Yeah, they were really good… but we need to get rid of the evidence."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Why?"),
new DialogueLine(characterName = "Rose", dialogue = " He shouldn’t know that we ate without his permission."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Huh?"),
new DialogueLine(characterName = "Yeonseo", dialogue = " Let’s just throw it out once we’re done and go to sleep."),
new DialogueLine(characterName = " ", dialogue = "We all help each other clean up and throw everything away. It makes me feel uneasy… Why do I have to hide the fact that I ate?"),
new DialogueLine(characterName = " ", dialogue = "After that, Rose and Xuan Mo go to the gym to burn off the food, which I actually find kind of funny."),
new DialogueLine(characterName = " ", dialogue = "Yeonseo goes straight to bed. I follow her."),

//DORM ROOM
new DialogueLine(characterName = " ", dialogue = "notification from tablet "),
new DialogueLine(characterName = "Yeonhee", dialogue = "What’s that…?"),
new DialogueLine(characterName = " ", dialogue = "I glance at the tablet."),
new DialogueLine(characterName = "Yeonhee", dialogue = "Oh… I got a message."),
new DialogueLine(characterName = " ", dialogue = "Anonymous: Leave while you still can."),
new DialogueLine(characterName = "Yeonhee", dialogue = "“Leave while you still can?"),
new DialogueLine(characterName = " ", dialogue = "Lol… What a childish way to scare competition. I’m going to sleep. …but what if…"),
new DialogueLine(characterName = " ", dialogue = "Ugh… never mind.")
        };

        chapter1Index = 0;
        ShowLine();
    }

    public void NextLine()
    {
        chapter1Index++;
        ShowLine();
    }

    void ShowLine()
    {
        if (chapter1Index < chapter1Lines.Count)
        {
            dialogueText.text = chapter1Lines[chapter1Index];
        }
    }
}
