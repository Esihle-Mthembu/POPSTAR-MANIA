
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Chapter1 : MonoBehaviour
{
    public DialogueLine[] dialogueLines;
    public DialogueUIManager ui;

    public DialogueLine[] chapterLines;
    private int index = 0;

    private bool isChoosing = false;

    void Start()
    {
        dialogueLines = new DialogueLine[]
        {
//OUTSIDE THE COMPANY BUILDING
new DialogueLine(" ", "When I got back home, my parents and friends were so excited about the news. Even my dad, who was so against the idea, finally warmed up to it."),//0
new DialogueLine(" ", "And now, here I am, standing outside this building with my parents, wondering what my future will look like when I achieve my dreams. Standing here feels weird… I never thought this would happen to me."),
new DialogueLine( " ", "I’m nervous about meeting the other girls."),
new DialogueLine( " ", "I heard they’ve been here longer than me… that gives them an advantage. I really need to work my ass off. But for now, I’ll just try to get the hang of things."),
new DialogueLine( "Mom", " You should call us if anything happens, okay?"),
new DialogueLine( "Dad", " Don’t forget about your schoolwork while you're here."),//5
new DialogueLine( " ", "Hearing my dad say this while holding my bags makes it feel real."),
new DialogueLine( " ", "I roll my eyes before answering."),
new DialogueLine( "Yeonhee", "I won't forget and I promise to call."),
new DialogueLine( "", "After a short wait, the door swings open, and a familiar face steps out."),
new DialogueLine( "Panel member 1", " It’s good to see you again, Yeonhee. This must be your parents, I assume?"),//10
new DialogueLine( " ", "Oh… the panel member from that day. Her smile still looks creepy. I nod."),
new DialogueLine( "Panel member 1", " Thank you for bringing her. I’ll take over from here."),
new DialogueLine( "Dad", " Oh? We were hoping we could just come in and."),
new DialogueLine( " ", "The panel member cuts him off, still smiling."),
new DialogueLine( "Panel member 1", " I’m sorry, but parents aren’t allowed in the dorms. Not allowed?"),//15
new DialogueLine( "Mom", " Uhh… I guess it’s okay. You’ll be fine alone, right?"),
new DialogueLine( " ", "I nod, unsure."),
new DialogueLine( "Yeonhee", "Yeah… I’ll be fine."),
new DialogueLine( " ", "I hug my parents quickly, my heart racing as I watch their car disappear."),

//COMPANY LOBBY
new DialogueLine( "Panel member 1", " Before we proceed, I’ll need your phone."),//20
new DialogueLine( "Yeonhee", "…My phone?"),
new DialogueLine( "Panel member 1", " Personal devices aren’t permitted. You’ll be provided with an alternative."),
new DialogueLine( "Yeonhee", "But how will I call my parents? I promised I would."),
new DialogueLine( " ", "The panel member reaches out her hand, still smiling, without answering. This feels weird… but I guess it’s just company rules."),
new DialogueLine( " ", "I hand over my phone."),//25
new DialogueLine( "Panel member 1", " Thank you. Follow me."),
new DialogueLine( " ", "As we walk through the hallway, I notice how quiet the company is, even though we pass training rooms."),
new DialogueLine( " ", "We enter a large door, and behind it are different units stretching down the hall. This must be it…"),
new DialogueLine( "Panel member 1", " This is where the other trainees live. Your unit is right down this hall."),
new DialogueLine( " ", "The panel member fumbles through her keys. I stand behind her, listening to the chatter bleeding through the walls. Everyone is talking about training or diets… nothing fun."),//30
new DialogueLine( "Panel member 1", " Got it. Here’s your unit and your key."),
new DialogueLine( "Panel member 1", " This is where I’ll leave you. I can’t wait to bump into you again, Yeonhee."),
new DialogueLine( " ", "We exchange smiles."),
new DialogueLine( " ", "I look down at my keys and try the door, and it's already unlocked. I guess everyone’s home…"),

//DORM
new DialogueLine( " ", "I step in anxiously, and before I can look around, all seven trainees greet me. As everyone introduced themselves I tried to peek through the small gaps to see what the unit looked like, but everyone was taller than me, making it harder to take a peak."),//35
new DialogueLine( " ", "Geez, why is everyone in my face…"),
new DialogueLine( "Cheonmi", " Hi, I’m Cheomni, I’m 19."),
new DialogueLine( " ", "She looks me up and down."),
new DialogueLine( "Cheonmi", " I hope you pick things up quickly."),
new DialogueLine( " ", "Okay that sounds a bit rude… but she's so pretty. She actually looks like an idol already."),//40
new DialogueLine( "Yeonseo", " Hi, I’m Yeonseo, I’m 23…i’ve been training here the longest but please don’t call me unnie. Also don’t mind Cheomni, she gets like that sometimes. If you need help, call me."),
new DialogueLine( "Xuan Mo", " Hi, I’m Xuan Mo, 16… it’s nice to meet you."),
new DialogueLine( " ", "Finally, someone my height. She’s the youngest and looks the most depressed… life hasn’t been easy for her, I guess."),
new DialogueLine( "Rose", "Hi! I’m Rose, I’m Filipina, 20. I’ll also be a call away if you need help, with literally anything."),
new DialogueLine( " ", "She’s way shorter than me, that's actually very rare… I’d like to be friends, she seems free spirited just like me."),//45
new DialogueLine( " ", "Everyone seems nice and unique… I feel less anxious."),
new DialogueLine( "Yeonhee", "Hi! Uh… I didn’t prepare an intro, but I’m Yeonhee, 18.. (I bow)."),
new DialogueLine( " ", "Cheomni laughs and walks away."),
new DialogueLine( " ", "Seems people like laughing here…"),
new DialogueLine( " ", "Everyone else disappears into the unit, except Rose. She stares at me for a moment before speaking."),//50
new DialogueLine( "Rose", " Your bags are heavy."),
new DialogueLine( " ", "Let me help you carry them to our room"),
new DialogueLine( "Yeonhee", "Oh… you’re my roommate?"),
new DialogueLine( " ", "Rose smiles."),
new DialogueLine( "Rose", " We all stay in the same room."),//55
new DialogueLine( "Yeonhee", "We all share one… room?"),

//DORM ROOM
new DialogueLine( " ", "Rose opened the door and I froze. I had never seen so many bunk beds crammed into one room before."),
new DialogueLine( " ", "A single tiny window let in a bit of light."),
new DialogueLine( " ", "Everyone had to share a single makeup table, which was covered in neatly labeled products."),
new DialogueLine( " ", "Lipsticks, foundations, lotions, hair dryers, even shoes were all lined up. Somehow, despite seven people living here, the room was surprisingly tidy."),//60
new DialogueLine( "Rose", " Yep, this is where we all live. You share a bunk with Xuan Mo, your bed is on top."),
new DialogueLine( "Yeonhee", "Wow… it’s my first time seeing someone willingly choose the bottom bunk."),
new DialogueLine( "Rose", " Hah, yeah…"),
new DialogueLine( "Rose", " Anyways, there’s a tablet on your bed. It’s your personal tablet from the company. You can chat with the other trainees, get updates, and track your progress after every challenge."),
new DialogueLine( "Yeonhee", "Challenges?"),//65
new DialogueLine( "Rose", " I’ll explain after we check everything else."),
new DialogueLine( "Rose", " You’ve seen the room, right?"),
new DialogueLine( "Yeonhee", "Yeah… not much to look at."),
new DialogueLine( "Rose", " Don’t forget this."),
new DialogueLine( " ", "She points to a scale outside the door."),//70
new DialogueLine( "Yeonhee", "A scale?"),
new DialogueLine( "Rose", " We weigh ourselves every morning for the trainers. You can’t go over 50kg or under 45kg. They want us fit, but not sickly looking."),
new DialogueLine( "Yeonhee", "Uh… okay?"),
new DialogueLine( " ", "50kg for adults? I haven’t checked in years… I snack a lot…"),
new DialogueLine( "Rose", " Let’s check your weight."),//75
new DialogueLine( " ", "I step on the scale nervously."),
new DialogueLine( "Yeonhee", "Okay…"),
new DialogueLine( " ", "49.7kg. My heart sinks."),
new DialogueLine( "Rose", " You’re treading on thin ice already… keep your weight in check. This is strict… I knew K-pop companies checked weight, but not like this…"),

//DORM KITCHEN
new DialogueLine( "Rose", " Anyways this is the kitchen, we share meals here and talk…sometimes, this is the fridge we share with everyone in the unit."),//80
new DialogueLine( " ", "Rose points to the bar fridge."),
new DialogueLine( "Yeonhee", "Who’s fridge is this?"),
new DialogueLine( "Rose", " It's everyone's fridge."),
new DialogueLine( " ", "One bar fridge?."),
new DialogueLine( " ", "I opened it and I couldn't help but hide my shocked expression, it was empty, just a few Diet soda’s and eggs."),//85
new DialogueLine( " ", "I guess my snacks will fit."),
new DialogueLine( " ", "I pull out snacks my mom packed. Rose’s face goes grey."),
new DialogueLine( " ", "Cheomni walks over aggressively."),
new DialogueLine( "Cheonmi", " What are you doing? You’re not putting… THAT… in there."),
new DialogueLine( "Yeonhee", "Excuse me?"),//90
new DialogueLine( "Cheonmi", " Throw it away."),


    new DialogueLine(" ", "I grip my snacks, thinking… What should I say?")
{
        hasChoices = true,
        choices = new DialogueChoice[]
        {
            new DialogueChoice { choiceText = "1. No, what’s your deal with my things anyways?", nextLineIndex = 93 },
            new DialogueChoice { choiceText = "2. My mom made these for me, so I won’t waste her food.", nextLineIndex = 93 },
            new DialogueChoice { choiceText = "3. Oh… yeah, I get it, it’s unhealthy… I’ll throw them away, sorry.", nextLineIndex = 167 }
        }
},

//option 1 and 2 outcome
//[OPTIONS 1 AND 2]
//[Relationship status with Xuan Mo:Grows, trainees: Neutral, Cheonmi: lowers] 

//COMPANY LOBBY
new DialogueLine("Cheonmi", "Are you actually joking?"),
new DialogueLine("Yeonhee", "Why would I?, you can’t just tell me what-"),
new DialogueLine(" ", "Rose laughs anxiously and pushes ime away from the situation"),//95
new DialogueLine("Yeonhee", "Hey, stop pushing me."),
new DialogueLine("Rose", " Sorry, it’s just… I wouldn’t recommend annoying Cheomni or pressing her buttons."),
new DialogueLine("Yeonhee", "Why?"),
new DialogueLine("Rose", " Just don’t."),
new DialogueLine(" ", "Who is she anyways? It’s annoying how everyone treats her like a god…"),//100

//DANCE STUDIO
new DialogueLine(" ", "Rose stops at a door."),
new DialogueLine("Rose", " You were pretty cool though, the last person to stand up to Cheomni was Xuan Mo."),
new DialogueLine("Yeonhee", "…and?"),
new DialogueLine("Rose", " Nothing happened. I’m just saying. I didn’t ask if something happened…"),
new DialogueLine(" ", "I watch as Rose quietly opens the door and points down at another scale near the entrance."),//105
new DialogueLine(" ", "Another scale? Is this for when I forget to weigh myself in the morning?"),
new DialogueLine("Rose", " Yeah, we have another scale. This one is for the manager to track our weight. He asks for your weight in the morning and then weighs you again."),
new DialogueLine("Yeonhee", "What happens if I go over the weight limit?"),
new DialogueLine("Rose", " You just have to go on a diet… and do a few things…"),
new DialogueLine(" ", "What things…"),//110
new DialogueLine("Rose", " Anyways, this is the dance studio. We do all our practice here."),
new DialogueLine(" ", "Rose takes me through the vocal studio and explains how after each practice, we have a challenge round where we all compete for points."),

//DORM
new DialogueLine(" ", "When we get back to the dorm, she finally shows me the scoreboard she said she’d show me earlier."),
new DialogueLine("Rose", " To access your scoreboard at any point, just tap this icon on your tablet and the scoreboard will pop up. But after challenges, we check our scores immediately. It’s the first thing all the girls love to check after practice."),

//Score of the day:
//1.Cheomni
//2.Yeonseo
//3.Kandy
//4.Minjii
//5.Mei
//6.Xuan Mo
//7.Rose
//8.Yeonhee

new DialogueLine(" ", "I notice that Rose, Xuan Mo, and I are all at the bottom while Cheomni is right at the top."),//115
new DialogueLine(" ", "I can’t help but dissociate and stare at the scoreboard…"),
new DialogueLine(" ", "Yeonseo taps my shoulder."),
new DialogueLine("Yeonseo", " If you want to reach Cheomni’s position, you’ll have to really try hard in every single thing you do."),
new DialogueLine("Yeonhee", "Huh?"),
new DialogueLine("Yeonseo", " Nothing… you should go get changed, we’re about to have training."),//120
new DialogueLine("Yeonhee", "Okay…"),

//DORM ROOM
new DialogueLine(" ", "I throw myself onto the bed and try to breathe through the stuffy room."),
new DialogueLine(" ", "That was weird… but I’ll just forget about it for now. She’s probably trying to throw me off. It’s a competition at the end of the day anyways."),
new DialogueLine(" ", "The person I’m most curious about is Cheomni. I hope I didn’t get on her bad side, but she was honestly doing the most."),
new DialogueLine(" ", "Rose seems pretty cool too, the fact that she showed me around is nice. And Xuan Mo… I don’t know much about her. She hasn’t spoken another word since she introduced herself."),//125
new DialogueLine(" ", "The company seems strict, and the living conditions are a bit uncomfortable. I wish I could talk to my mom right now, but I guess I have to be strong."),
new DialogueLine(" ", "Cheomni walks into the room, looks up at me, and sighs. She grabs her shoes and leaves.I get up and notice the dorm is quieter. Rose swings the door open quickly."),
new DialogueLine("Rose", " You’re going to be late for practice. Didn’t Cheomni come in and call you? Come on. put on your shoes. We have lyrical practice."),
new DialogueLine("Yeonhee", "No, she didn’t. I’ll be down now."),
new DialogueLine(" ", "She literally walked in and didn’t tell me about practice… I guess the only people I can depend on are Rose and possibly Yeonseo."),//130

//PRACTICE ROOM
new DialogueLine(" ", "When we arrive, the manager stands at the door with a piece of paper. He’s a tall, tanned man in an all-black suit."),
new DialogueLine(" ", "His stare creeps me out."),
new DialogueLine(" ", "I peek inside and see the trainer with his feet propped on the table. I breathed a sigh of relief…"),
new DialogueLine(" ", "He seems to be more relaxed than the manager."),
new DialogueLine("Manager", " I hope you’re all well rested and ready for practice. We’ve decided to add another scale at the vocal practice room. Don’t ask me why, I really tried to convince them otherwise girls, they just wouldn't budge."),//135
new DialogueLine(" ", "He smiles, but something tells me that’s a lie."),
new DialogueLine(" ", "Xuan Mo scratches her neck anxiously. The manager notices and looks straight at her."),
new DialogueLine("Manager", " Xuan Mo, let’s start with you. What is your weight?"),
new DialogueLine("Xuan Mo", " Uhh… 44.9 kg."),
new DialogueLine(" ", "Rose whispers under her breath: Still underweight."),//140
new DialogueLine(" ", "She steps on the scale, and it goes to 43 kg. The manager’s face changes immediately."),
new DialogueLine("Manager", " You lied, Xuan Mo. When will you get your weight up? Fix this by next practice. Today I’ll excuse you because we have a new trainee."),
new DialogueLine(" ", "Xuan Mo shakes past him. I watch as each girl walks in, anxiety written all over their faces. Cheomni is the only one looking confident."),
new DialogueLine(" ", "When it’s finally my turn, I get cold feet."),
new DialogueLine("Manager", " Hi Yeonhee, I’m so upset these are our introductions… but this is my job, you understand right…"),//145
new DialogueLine(" ", "I nod anxiously"),
new DialogueLine("Manager", " What is your weight?"),
new DialogueLine(" ", "Shoot… what was it again, dammit I forgot… be confident, be confident, be confident."),
new DialogueLine("Yeonhee", "49.7 kg"),
new DialogueLine(" ", "Yes I remembered."),//150
new DialogueLine("Manager", " Hmmmm"),
new DialogueLine(" ", "I step on the scale. The number drops by one… 49. 6 kg. I feel his glare pierce through me."),
new DialogueLine("Manager", " One point wrong… and you need to start a diet."),
new DialogueLine(" ", "I walk past him shaky. That was the most intense feeling I’ve had in a long time… not even my school exams stressed me this bad."),
new DialogueLine("Trainer", " Welcome back girls, and Yeonhee, I hope you’ve settled in well. Today we’re going to memorize lyrics. As you know, when you perform, we expect you to remember all your parts, even if you’re lip-syncing. Memorizing the lyrics makes it look realistic."),//155
new DialogueLine(" ", "I’ll play the lyrics a few times, and each of you will have to memorize them. I may test you now or later this week, so hold onto that thought."),
new DialogueLine(" ", "Cheomni leans in and whispers in my ear."),
new DialogueLine("Cheonmi", " Trainers usually say this when they’ll give you the material to practice at home. I feel like they’re going easy because of you."),
new DialogueLine("Trainer", " Yeonhee! No chatter. Don’t be a troublemaker just because you’re new. All the other trainees stare at me."),
new DialogueLine("Yeonhee", "Sorry, it won’t happen again…"),//160
new DialogueLine(" ", "Why did he scold me when it wasn’t even my fault?"),
new DialogueLine("Trainer", " Today we’ll sing a new song so nobody has an advantage over Yeonhee. This song has been in progress. We’re going in the direction of cute girl krush concepts today. When you sing it back, try to sound cute… more aegyo."),
new DialogueLine(" ", "Cute? Girl krush? Are you joking?"),
new DialogueLine("Trainer", " Pay attention to the lyrics. We’ll play the songs twice today. The trainer glaring at me."),
new DialogueLine(" ", "I immediately tense up."),//165
new DialogueLine("Cheonmi", " Wow… generous. She says out loud.")

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

{
    isEnding = true
},

//option 3 outcome
//[OPTION 3]
//[Relationship status trainees: Neutral, Cheonmi: grows] 

//COMPANY LOBBY
new DialogueLine("Cheonmi", "Great. Don’t bring that around again."),//167
new DialogueLine(" ", "My face instantly changed, despite me agreeing, I couldn’t help but get annoyed."),
new DialogueLine(" ", "Rose laughs nervously and pushes me away from the situation."),
new DialogueLine("Yeonhee", " Hey, stop pushing me."),//170
new DialogueLine("Rose", " Sorry, it’s just… I wouldn’t recommend annoying Cheomni or pressing her buttons again."),
new DialogueLine("Rose", " It’s a good thing you were able to calm down the situation."),
new DialogueLine("Yeonhee", "Why?"),
new DialogueLine("Rose", " Just don’t do it again."),
new DialogueLine(" ", "Who is she anyway? It’s annoying that everyone treats her like a god. I only agreed not to start anything because I didn’t want conflict on my first day."),

//DANCE STUDIO
new DialogueLine(" ", "Rose stops at a door."),
new DialogueLine("Rose", " The only person who has stood up to Cheomni was Xuan Mo."),
new DialogueLine("Yeonhee", "…and?"),
new DialogueLine("Rose", " Nothing happened. I’m just saying."),
new DialogueLine(" ", "I never asked if anything happened…"),
new DialogueLine(" ", "I watch as Rose quietly opens the door and points down at another scale at the entrance."),
new DialogueLine(" ", "Another scale? Is this for when I forget to weigh myself in the morning?"),
new DialogueLine("Rose", " Yeah, we have another scale. This one is for the manager to track our weight. He asks for your weight in the morning and then weighs you again."),
new DialogueLine("Yeonhee", "What happens if I go over the weight limit?"),
new DialogueLine("Rose", " You just have to go on a diet… and do a few things…"),
new DialogueLine(" ", "What things…"),
new DialogueLine("Rose", " Anyways, this is the dance studio. We do all our practice here."),
new DialogueLine(" ", "Rose takes me through the vocal studio and explains that after each practice we have a challenge round where everyone competes for points to impress the managers and recruiters."),

//DORM
new DialogueLine(" ", "When we get back to the dorm, she finally shows me the scoreboard she said she’d show me earlier."),
new DialogueLine("Rose", " To access your scoreboard at any point, just tap this icon on your tablet and the scoreboard will pop up. But after challenges, we check our scores immediately. It’s the first thing all the girls love to check after practice."),
new DialogueLine(" ", "I notice that Rose, Xuan Mo, and I are all at the bottom while Cheomni is right at the top."),

//Score of the day:
//1.Cheomni
//2.Yeonseo
//3.Kandy
//4.Minjii
//5.Mei
//6.Xuan Mo
//7.Rose
//8.Yeonhee

new DialogueLine(" ", "I can’t help but dissociate and stare at the scoreboard…"),
new DialogueLine(" ", "Yeonseo taps me."),
new DialogueLine("Yeonseo", " If you want to reach Cheomni’s position, you’ll have to really try hard in everything you do."),
new DialogueLine("Yeonhee", "Huh?"),
new DialogueLine("Yeonseo", " Nothing… you should go get changed, we’re about to have training."),
new DialogueLine("Yeonhee", " Okay… "),

//DORM ROOM
new DialogueLine(" ", "I throw myself onto the bed and try to breathe in the stuffy room."),
new DialogueLine(" ", "That was weird… but I’ll just forget about it for now. She’s probably trying to throw me off. It’s a competition at the end of the day anyways."),
new DialogueLine(" ", "The person I’m most curious about is Cheomni. I hope I was actually able to calm down the situation., but she was honestly doing the most."),
new DialogueLine(" ", "Rose seems pretty cool too, the fact that she showed me around is nice. And Xuan Mo… I don’t know much about her. She hasn’t spoken another word since she introduced herself."),
new DialogueLine(" ", "The company seems strict, and the living conditions are a bit uncomfortable. I wish I could talk to my mom right now, but I guess I have to be strong."),
new DialogueLine(" ", "Cheomni walks into the room, looks up at me, and sighs."),
new DialogueLine("Cheonmi", " Don’t rest yet. We have practice right now."),
new DialogueLine("Yeonhee", " Really? Thank you for telling me."),
new DialogueLine(" ", "Cheomni smiles and grabs her shoes."),
new DialogueLine(" ", "A few seconds later, Rose walks in."),
new DialogueLine("Rose", " Oh, you’re already dressed. Did Cheomni just come in and call you?"),
new DialogueLine("Yeonhee", " Yeah, she did."),
new DialogueLine("Rose", " Oh… okay, let’s go."),
new DialogueLine(" ", "Why does she look confused? I guess Cheomni doesn’t do this often… lucky me. It seems I have a lot of people I can depend on."),

//PRACTICE ROOM
new DialogueLine(" ", "When we arrive, the manager stands at the door with a piece of paper. He’s a tall, tanned man in an all-black suit."),
new DialogueLine(" ", "His stare creeps me out."),
new DialogueLine(" ", "I peek inside and see the trainer with his feet propped on the table. I breathed a sigh of relief…"),
new DialogueLine(" ", "He seems to be more relaxed than the manager."),
new DialogueLine("Manager", " I hope you’re all well rested and ready for practice. We’ve decided to add another scale at the vocal practice room. Don’t ask me why, I really tried to convince them otherwise girls, they just wouldn't budge."),
new DialogueLine(" ", "He smiles, but something tells me that’s a lie."),
new DialogueLine(" ", "Xuan Mo scratches her neck anxiously. The manager notices and looks straight at her."),
new DialogueLine("Manager", " Xuan Mo, let’s start with you. What is your weight?"),
new DialogueLine("Xuan Mo", " Uhh… 44.9 kg."),
new DialogueLine(" ", "Rose whispers under her breath: Still underweight."),
new DialogueLine(" ", "She steps on the scale, and it goes to 43 kg. The manager’s face changes immediately."),
new DialogueLine("Manager", " You lied, Xuan Mo. When will you get your weight up? Fix this by next practice. Today I’ll excuse you because we have a new trainee."),
new DialogueLine(" ", "Xuan Mo shakes past him. I watch as each girl walks in, anxiety written all over their faces. Cheomni is the only one looking confident."),
new DialogueLine(" ", "When it’s finally my turn, I get cold feet."),
new DialogueLine("Manager", " Hi Yeonhee, I’m so upset these are our introductions… but this is my job, you understand right…"),
new DialogueLine(" ", "I nod anxiously"),
new DialogueLine("Manager", " What is your weight?"),
new DialogueLine(" ", "Shoot… what was it again, dammit I forgot… be confident, be confident, be confident."),
new DialogueLine("Yeonhee", "49.7 kg"),
new DialogueLine(" ", "Yes I remembered."),
new DialogueLine("Manager", " Hmmmm"),
new DialogueLine(" ", "I step on the scale. The number drops by one… 49. 6 kg. I feel his glare pierce through me."),
new DialogueLine("Manager", " One point wrong… and you need to start a diet."),
new DialogueLine(" ", "I walk past him shaky. That was the most intense feeling I’ve had in a long time… not even my school exams stressed me this bad."),
new DialogueLine("Trainee", " Welcome back girls, and Yeonhee, I hope you’ve settled in well. Today we’re going to memorize lyrics. As you know, when you perform, we expect you to remember all your parts, even if you’re lip-syncing. Memorizing the lyrics makes it look realistic."),
new DialogueLine(" ", "I’ll play the lyrics a few times, and each of you will have to memorize them. I may test you now or later this week, so hold onto that thought."),
new DialogueLine(" ", "Cheomni leans in and whispers in my ear."),
new DialogueLine("Cheonmi", " Trainers usually say this when they expect you to pick things up quickly."),
new DialogueLine("Trainer", " Yeonhee! No chatter. Don’t be a troublemaker just because you're new."),
new DialogueLine(" ", "All the other trainees stare at me."),
new DialogueLine("Cheonmi", " It was my fault. It won’t happen again."),
new DialogueLine("Trainer", " Okay, I’ll let this slide since it’s not your usual behaviour."),
new DialogueLine(" ", "Why did he only scold me when it wasn’t my fault? I’m just glad Cheomni stood up for me."),
new DialogueLine("Trainer", " Today we’ll sing a new song so nobody has an advantage over Yeonhee. This song has been in progress. We’re going in the direction of cute and girl krush concepts today. When you sing it back, try to sound cute… use more aegyo."),
new DialogueLine(" ", "Cute? Girl krush? Are you joking?"),
new DialogueLine("Trainer", " Pay attention to the lyrics. We’ll play the songs twice today."),
new DialogueLine("Cheonmi", " Wow… generous. She says out loud."),
new DialogueLine(" ", "The trainer winks at me."),
new DialogueLine(" ", "I immediately get chills."),
new DialogueLine(" ", "Weird…he was just scolding me a few seconds ago.")

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

{
    isEnding = true
},

//Cheomni's good side branch2
//[Gained good points during the challenge]

//PRACTICE ROOM
new DialogueLine(" ", "My heart is pounding… that was so difficult. I really need to work on my vocals. Rose sounded amazing, even though she messed up."),
new DialogueLine(" ", "All the girls sit together on the couch while the manager and trainer talk on the other side of the room."),
new DialogueLine(" ", "I wonder what they’re saying about me… the trainer keeps looking my way."),
new DialogueLine(" ", "To my surprise, Cheomni is sitting alone on the other side of the room. She looks at me and smiles."),
new DialogueLine(" ", "Something about that smile feels fake… it almost feels like she’s upset that I did well. But maybe I’m just overthinking it."),
new DialogueLine(" ", "That challenge was intense. What made the situation worse was the trainer yelling at everyone… he’s not as chill as I thought he’d be."),
new DialogueLine(" ", "I feel really bad for Xuan Mo though… he wouldn’t get off her back. Maybe I should check on her."),
new DialogueLine("Yeonhee", "Hey Xuan Mo, are you okay? You’re sweating a lot."),
new DialogueLine(" ", "Xuan Mo looks at me and sighs."),
new DialogueLine("Xuan Mo", " I’m fine."),
new DialogueLine("Yeonhee", "Okay… I was just worried. You seem a bit out of it right now."),
new DialogueLine("Xuan Mo", " You should worry about yourself here."),
new DialogueLine(" ", "Well damn… I guess this is why nobody talks to her. She makes it really difficult… but I’ll still try."),
new DialogueLine("Cheonmi", " Leave her. She’s always like this. Don’t waste your precious breath. The room goes quiet."),
new DialogueLine("Cheonmi", " Today your performance was quite good for a newbie. She smiles."),
new DialogueLine(" ", "That didn’t feel like a compliment…"),
new DialogueLine("Yeonhee", "Haahh…Thank you."),
new DialogueLine("Manager", " So much chatter today. I see Yeonhee is quite the talker."),
new DialogueLine(" ", "Again… Why is it always me?"),
new DialogueLine(" ", "At least he broke the silence…"),
new DialogueLine("Yeonhee", "Sorry…"),
new DialogueLine("Trainer", " Let’s discuss today’s session. It seems we’ve been too soft on some of you… to the point where a newbie surpasses you on her first try. Ridiculous."),
new DialogueLine(" ", "The room goes tense."),
new DialogueLine("Trainer", " Yeonhee, your voice… work on it. It sounds childish. I asked for cute, not toddler."),
new DialogueLine(" ", "Wow… okay."),
new DialogueLine("Trainer", " Xuan Mo, forgetting lyrics again. Have you even been attending your language classes ? Your Korean sounds choppy."),
new DialogueLine(" ", "Xuan Mo keeps the same expressionless look she does all the time."),
new DialogueLine("Trainer", " Rose, your voice is too powerful. If you want to be a solo artist, then leave. Stop trying to outshine everyone. At least your Korean is understandable."),
new DialogueLine(" ", "Rose looks down quietly."),
new DialogueLine("Trainer", " Yeonseo, you were good. Just fix the voice cracks."),
new DialogueLine("Yeonseo", " Thank you, sir!"),
new DialogueLine(" ", "The trainer pauses, then looks at Cheomni."),
new DialogueLine(" ", "I feel nervous for her… she made the most mistakes."),
new DialogueLine("Trainer", " Cheomni, perfect as always. Just work on remembering your lyrics without stuttering."),
new DialogueLine(" ", "What? That’s not fair… she messed up the most."),
new DialogueLine("Trainer", " Evaluations are over. Fix what I told you. I don’t want to hear these mistakes again."),
new DialogueLine(" ", "He leaves."),
new DialogueLine(" ", "The room finally feels lighter."),
new DialogueLine("Manager", " Good job, girls. We just need more practice. See you tomorrow. He looks calm… but I can literally see a vein popping on his forehead. What's wrong with him?"),

//COMPANY LOBBY
new DialogueLine(" ", "We all start heading back to the dorm."),
new DialogueLine("Rose", " Well… I guess we’re sleeping early today."),
new DialogueLine("Yeonhee", "Why?"),
new DialogueLine("Yeonseo", " You’ll see.”"),
new DialogueLine(" ", "Hmmmm"),
new DialogueLine(" ", "I can’t stop thinking about Rose’s voice… I barely even hear the conversation."),
new DialogueLine("Yeonhee", "Uh… Rose… I think you have a really beautiful voice. I want to sing like you someday."),
new DialogueLine(" ", "Rose smiles softly, but before she can reply"),
new DialogueLine("Cheonmi", " Your opinion doesn’t really matter here. If you want to succeed, listen to the trainers… not Rose"),
new DialogueLine("Yeonseo", " I guess that didn’t work out for you today though."),
new DialogueLine(" ", "Cheomni’s expression tightens, but she says nothing and walks ahead. There’s so much tension here…"),

//DORM
new DialogueLine(" ", "Back at the dorm, everyone gathers around to check their scoreboards."),
new DialogueLine(" ", "My score went up… I’m actually close to passing Xuan Mo. On my first day… that’s insane."),

//Score of the day:
//1.Cheomni
//2.Yeonseo
//3.Kandy
//4.Minji
//5.Rose
//6.Xuan Mo
//7.Yeonhee
//8.Mei

new DialogueLine("Rose", " Wow, you moved up already… congrats."),
new DialogueLine(" ", "She smiles, but she looks worried."),
new DialogueLine("Yeonhee", "Thank you!"),
new DialogueLine(" ", "I’m actually really proud of myself today… even if my evaluation was bad. I can’t wait to see what tomorrow brings."),
new DialogueLine(" ", "But first… I need food. I’m starving."),

//DORM KITCHEN
new DialogueLine(" ", "I walk into the kitchen."),
new DialogueLine(" ", "Nothing."),
new DialogueLine("Yeonhee", "Uh… when do we eat?"),
new DialogueLine("Cheonmi", " We didn’t do well today."),
new DialogueLine("Yeonhee", "What does that have to do with anything?"),
new DialogueLine("Yeonseo", " It means the manager doesn’t get us dinner."),
new DialogueLine(" ", "What? That’s insane. Xuan Mo looks like she’s about to pass out… everyone worked so hard. And they choose to punish us with food?"),
new DialogueLine("Yeonhee", "How is that allowed?"),
new DialogueLine("Xuan Mo", " it’s allowed, they wrote it in the contract."),
new DialogueLine(" ", "oh…I didn’t read that"),
new DialogueLine("Yeonseo", " You shouldn’t have thrown your snacks away. We would’ve had something to eat."),
new DialogueLine(" ", "I knew I shouldn't have done that."),
new DialogueLine("Cheonmi", " We’ll survive without food. We always do."),
new DialogueLine(" ", "Always…?"),
new DialogueLine("Cheonmi", " Don’t worry, Yeonhee. You’ll adapt soon."),
new DialogueLine(" ", "She smiles again."),
new DialogueLine(" ", "This time… it doesn’t feel comforting at all."),
new DialogueLine(" ", "I guess this really is my life now… I need to work harder."),
new DialogueLine("Yeonhee", "Okay then."),
new DialogueLine(" ", "Yeonseo rolls her eyes and heads to bed. Everyone else slowly disappears. I follow behind her."),

//DORM ROOM
new DialogueLine(" ", "The least I can do is sleep through the hunger."),
new DialogueLine(" ", "*notification from tablet*"),
new DialogueLine("Yeonhee", "What’s that…?"),
new DialogueLine(" ", "I glance at the tablet."),
new DialogueLine("Yeonhee", "Oh… I got a message."),
new DialogueLine(" ", "Anonymous: Leave while you still can."),
new DialogueLine("Yeonhee", "“Leave while you still can”?"),
new DialogueLine(" ", "Lol… What a childish way to scare competition. I’m going to sleep. …but what if…"),
new DialogueLine(" ", "Ugh… never mind."),

//Cheomni's good side branch
//[Gained bad points during the challenge]

//PRACTICE ROOM
new DialogueLine(" ", "My heart is pounding… that was so difficult."),
new DialogueLine(" ", "I can’t believe I did that bad. I really thought I’d get the hang of it immediately."),
new DialogueLine(" ", "Everyone sounded so good. Even with their mistakes, they still sounded amazing… and then there’s me."),
new DialogueLine(" ", "I really need to work on my vocals. Rose sounded incredible. It was like hearing an angel sing."),
new DialogueLine(" ", "All the girls sit together on the couch while the manager and trainer talk on the other side of the room."),
new DialogueLine(" ", "I wonder what they’re saying about me… the trainer keeps looking my way. I hope they don’t kick me out. I wouldn’t even blame them."),
new DialogueLine(" ", "But to my surprise, Cheomni is sitting alone on the other side of the room. She looks at me and smiles."),
new DialogueLine(" ", "She seems genuine… but I can’t shake this embarrassment."),
new DialogueLine(" ", "Maybe I’m just overthinking it. It is my first day after all."),
new DialogueLine(" ", "That challenge was intense. What made it worse was the trainer yelling at everyone… he’s not as chill as I thought. Not even close."),
new DialogueLine(" ", "I feel really bad for Xuan Mo though… he wouldn’t get off her back. Maybe I should check on her."),
new DialogueLine("Yeonhee", " Hey Xuan Mo, are you okay? You’re sweating a lot."),
new DialogueLine(" ", "Xuan Mo looks at me and sighs."),
new DialogueLine("Xuan Mo", " I’m fine."),
new DialogueLine("Yeonhee", " Okay… I was just worried. You seem a bit out of it."),
new DialogueLine("Xuan Mo", " You should worry about yourself here."),
new DialogueLine(" ", "Well damn… I guess this is why nobody talks to her. She makes it really difficult… but I’ll still try."),
new DialogueLine("Cheonmi", " Leave her. She’s always like this. Don’t waste your breath. The room goes quiet."),
new DialogueLine("Cheonmi", " Today your performance wasn’t bad for a newbie. You’ll get better with practice… I didn’t have it figured out when I first arrived either."),
new DialogueLine(" ", "She smiles."),
new DialogueLine(" ", "Okay… I need to give myself a break."),
new DialogueLine("Yeonhee", " Thank you… that’s actually comforting."),
new DialogueLine("Manager", " So much chatter coming from you, Yeonhee. You should get rid of that habit."),
new DialogueLine(" ", "Again… Why is it always me?"),
new DialogueLine(" ", "At least he broke the silence…"),
new DialogueLine("Yeonhee", " Sorry…"),
new DialogueLine("Trainer", " Let’s discuss today’s session. We’ve been too soft on some of you… I don’t know what happened, but today’s performance was absolutely ridiculous."),
new DialogueLine(" ", "The room goes tense."),
new DialogueLine("Trainer", " Yeonhee, your voice… work on it. It sounds childish. I asked for cute, not toddler. And what’s with forgetting such a simple lyric? If you want to stay in this company… pull up your socks. I’ll make a separate schedule for you outside of training hours. You need it."),
new DialogueLine(" ", "Wow… okay. He didn’t have to be that harsh."),
new DialogueLine("Trainer", " Xuan Mo, forgetting lyrics again. Have you even been attending your language classes? Your Korean sounds choppy."),
new DialogueLine(" ", "Xuan Mo keeps the same expressionless look."),
new DialogueLine("Trainer", " Rose, your voice is too powerful. If you want to be a solo artist, then leave. Stop trying to outshine everyone. At least your Korean is understandable."),
new DialogueLine(" ", "Rose looks down quietly."),
new DialogueLine("Trainer", " Yeonseo, you were good. Just fix the voice cracks."),
new DialogueLine("Yeonseo", " Thank you, sir!"),
new DialogueLine(" ", "The trainer pauses, then looks at Cheomni."),
new DialogueLine(" ", "I feel nervous for her… she made the most mistakes."),
new DialogueLine("Trainer", " Cheomni, perfect as always. Just work on remembering your lyrics without stuttering."),
new DialogueLine(" ", "What? That’s not fair… she messed up the most. Seriously… what is she, funding the company or something?"),
new DialogueLine("Trainer", " Evaluations are over. Fix what I told you. I don’t want to hear these mistakes again."),
new DialogueLine(" ", "He leaves."),
new DialogueLine(" ", "The room finally feels lighter."),
new DialogueLine("Manager", " Good job, girls. We just need more practice. See you tomorrow."),
new DialogueLine(" ", "He looks calm… but I can literally see a vein popping on his forehead. What’s wrong with him?"),

//COMPANY LOBBY
new DialogueLine(" ", "We all start heading back to the dorm."),
new DialogueLine("Rose", " Well… I guess we’re sleeping early today."),
new DialogueLine("Yeonhee", "Why?"),
new DialogueLine("Yeonseo", " You’ll see."),
new DialogueLine(" ", "Hmm…"),
new DialogueLine(" ", "I can’t stop thinking about Rose’s voice. I barely even hear the conversation."),
new DialogueLine("Yeonhee", "Uh… Rose… I think you have a really beautiful voice. I want to sing like you someday."),
new DialogueLine(" ", "Rose smiles softly, but before she can reply-"),
new DialogueLine("Cheonmi", " Your opinion doesn’t really matter here. If you want to succeed, listen to the trainers… not Rose."),
new DialogueLine("Yeonseo", " I guess that didn’t work out for you today though."),
new DialogueLine("Cheonmi", " …"),
new DialogueLine(" ", "Her expression tightens, but she says nothing and walks ahead."),
new DialogueLine(" ", "There’s so much tension here…"),

//DORM
new DialogueLine(" ", "Back at the dorm, everyone gathers to check their scoreboards."),
new DialogueLine(" ", "My score stayed the same… this is so disheartening. I really need to work harder."),

 //Score of the day:
//1.Cheomni
//2.Yeonseo
//3.Kandy
//4.Minjii
//5.Rose
//6.Mei
//7.Xuan Mo
//8.Yeonhee

new DialogueLine(" ", "Rose moved up two tiers… just a few hours ago we were right next to each other."),
new DialogueLine("Rose", " Don’t worry about the scores today. You did your best."),
new DialogueLine(" ", "That’s easy for you to say…"),
new DialogueLine("Yeonhee", "Thank you."),
new DialogueLine(" ", "Despite everything… I’m actually proud of myself for making it through that challenge.”), Even if my evaluation was bad."),
new DialogueLine(" ", "I can’t wait to see what tomorrow brings."),
new DialogueLine(" ", "But first… I need food. I’m starving."),

//DORM KITCHEN
new DialogueLine(" ", "I walk into the kitchen."),
new DialogueLine(" ", "Nothing."),
new DialogueLine("Yeonhee", "Uh… when do we eat?"),
new DialogueLine("Cheonmi", " We didn’t do well today."),
new DialogueLine("Yeonhee", " What does that have to do with anything?"),
new DialogueLine("Yeonseo", " It means the manager doesn’t get us dinner."),
new DialogueLine(" ", "What? That’s insane. Xuan Mo looks like she’s about to pass out… everyone worked so hard… and they punish us with food?"),
new DialogueLine("Yeonhee", "How is that allowed?"),
new DialogueLine("Xuan Mo", " It’s allowed. It’s in the contract."),
new DialogueLine(" ", "Oh… I didn’t read that."),
new DialogueLine("Yeonseo", " You shouldn’t have thrown your snacks away. We would’ve had something to eat."),
new DialogueLine(" ", "I knew I shouldn’t have done that."),
new DialogueLine("Cheonmi", " We’ll survive without food. We always do."),
new DialogueLine(" ", "Always…?"),
new DialogueLine("Cheonmi", " Don’t worry, Yeonhee. You’ll adapt soon."),
new DialogueLine(" ", "She smiles again."),
new DialogueLine(" ", "This time… it doesn’t feel comforting at all."),
new DialogueLine(" ", "I guess this really is my life now… I need to work harder."),
new DialogueLine("Yeonhee", "Okay then."),
new DialogueLine(" ", "Yeonseo rolls her eyes and heads to bed."),
new DialogueLine(" ", "Everyone else slowly disappears. I follow behind her."),

//DORM ROOM
new DialogueLine(" ", "The least I can do is sleep through the hunger."),
new DialogueLine(" ", "notification from tablet"),
new DialogueLine("Yeonhee", "What’s that…?"),
new DialogueLine(" ", "I glance at the tablet."),
new DialogueLine("Yeonhee", "Oh… I got a message."),
new DialogueLine(" ", "Anonymous: Leave while you still can."),
new DialogueLine("Yeonhee", "“Leave while you still can?"),
new DialogueLine(" ", "Lol… what a childish way to scare competition. I’m going to sleep. …but what if…"),
new DialogueLine(" ", "Ugh… never mind."),

//Cheomni's bad side branch
//[Gained good points during the challenge]

//PRACTICE ROOM
new DialogueLine(" ", "My heart is pounding… that was so difficult.I really need to work on my vocals.Rose sounded amazing, even though she messed up."),
new DialogueLine(" ", "All the girls sit together on the couch while the manager and trainer talk on the other side of the room."),
new DialogueLine(" ", "I wonder what they’re saying about me… the trainer keeps looking my way."),
new DialogueLine(" ", "To my surprise, Cheomni is sitting alone on the other side of the room. She glances at me, then looks back at the wall."),
new DialogueLine(" ", "Something about that glance… it almost feels like she’s upset that I did well. But maybe I’m just overthinking it."),
new DialogueLine(" ", "That challenge was intense. What made the situation worse was the trainer yelling at everyone… he’s not as chill as I thought he’d be."),
new DialogueLine(" ", "I feel really bad for Xuan Mo though… he wouldn’t get off her back. Maybe I should check on her."),
new DialogueLine("Yeonhee", "Hey Xuan Mo, are you okay? You’re sweating a lot."),
new DialogueLine(" ", "Xuan Mo looks at me and sighs."),
new DialogueLine("Xuan Mo", " I’m fine."),
new DialogueLine("Yeonhee", "Okay… I was just worried. You seem a bit out of it right now."),
new DialogueLine("Xuan Mo", " You should worry about yourself here."),
new DialogueLine(" ", "Well damn… I guess this is why nobody talks to her.She makes it really difficult… but I’ll still try."),
new DialogueLine("Cheonmi", " Leave her. She’s always like this."),
new DialogueLine(" ", "The room goes quiet."),
new DialogueLine(" ", "Cheomni stares at me for a moment, like she’s thinking about what to say."),
new DialogueLine("Cheonmi", " Your performance was questionable, but I guess it wasn’t that bad… just don’t start running to the top position now."),
new DialogueLine(" ", "That didn’t feel like a compliment…"),
new DialogueLine("Yeonhee", "Haahh… thanks."),
new DialogueLine("Manager", " So much chatter today. I see Yeonhee is quite the talker."),
new DialogueLine(" ", "Again… Why is it always me?"),
new DialogueLine(" ", "At least he broke the silence…"),
new DialogueLine("Yeonhee", "Sorry…"),
new DialogueLine("Trainer", " Let’s discuss today’s session. It seems we’ve been too soft on some of you… to the point where a newbie surpasses you on her first try. Ridiculous."),
new DialogueLine(" ", "The room goes tense."),
new DialogueLine("Trainer", " Yeonhee, your voice… work on it. It sounds childish. I asked for cute, not toddler."),
new DialogueLine(" ", "Wow… okay"),
new DialogueLine("Trainer", " Xuan Mo, forgetting lyrics again. Have you even been attending your language classes? Your Korean sounds choppy."),
new DialogueLine(" ", "Xuan Mo keeps that same expressionless look she always has."),
new DialogueLine("Trainer", " Rose, your voice is too powerful. If you want to be a solo artist, then leave. Stop trying to outshine everyone. At least your Korean is understandable."),
new DialogueLine(" ", "Rose looks down quietly."),
new DialogueLine("Trainer", " Yeonseo, you were good. Just fix the voice cracks."),
new DialogueLine("Yeonseo", " Thank you, sir!"),
new DialogueLine(" ", "The trainer pauses, then looks at Cheomni."),
new DialogueLine(" ", "As bad as it sounds… I actually can’t wait for her to get scolded. She’s been on her high horse since I got here… and she made the most mistakes out of everyone."),
new DialogueLine("Trainer", " Cheomni, perfect as always. Just work on remembering your lyrics without stuttering."),
new DialogueLine(" ", "What? That’s not fair… she messed up the most."),
new DialogueLine("Trainer", " Evaluations are over. Fix what I told you. I don’t want to hear these mistakes again."),
new DialogueLine(" ", "He leaves."),
new DialogueLine(" ", "The room finally feels lighter."),
new DialogueLine("Manager", " Good job, girls. We just need more practice. See you tomorrow."),
new DialogueLine(" ", "He looks calm… but I can literally see a vein popping on his forehead. What’s wrong with him?"),

//COMPANY LOBBY
new DialogueLine(" ", "We all start heading back to the dorm."),
new DialogueLine(" ", "Rose wraps her arm around mine while Yeonseo walks beside me. It feels like we’re getting closer… It makes today feel a little less exhausting."),
new DialogueLine("Rose", " Well… I guess we’re sleeping early today."),
new DialogueLine("Yeonhee", "Why?"),
new DialogueLine("Yeonseo", " You’ll see."),
new DialogueLine(" ", "Hmm…"),
new DialogueLine(" ", "I can’t stop thinking about Rose’s voice… I barely even hear the conversation."),
new DialogueLine("Yeonhee", "Uh… Rose… I think you have a really beautiful voice. I want to sing like you someday."),
new DialogueLine(" ", "Rose smiles softly, but before she can reply"),
new DialogueLine("Cheonmi", " Your opinion doesn’t really matter here. If you want to succeed, listen to the trainers… not Rose."),
new DialogueLine("Yeonseo", " I guess that didn’t work out for you today though."),
new DialogueLine(" ", "Cheomni’s expression tightens, but she says nothing and walks ahead. There’s so much tension here…"),

//DORM
new DialogueLine(" ", "Back at the dorm, everyone gathers to check their scoreboards."),
new DialogueLine(" ", "My score went up… I’m actually close to passing Xuan Mo. On my first day… that’s insane."),

//Score of the day:
//1.Cheomni
//2.Yeonseo
//3.Karla
//4.Minji
//5.Rose
//6.Xuan Mo
//7.Yeonhee
//8.Mei

new DialogueLine("Rose", " Wow, you moved up already… congrats."),
new DialogueLine(" ", "She smiles, but she looks worried."),
new DialogueLine("Yeonhee", "Thank you!"),
new DialogueLine(" ", "I’m actually really proud of myself today… even if my evaluation was bad. I can’t wait to see what tomorrow brings."),
new DialogueLine(" ", "But first… I need food. I’m starving."),

//DORM KITCHEN
new DialogueLine(" ", "I walk into the kitchen."),
new DialogueLine(" ", "Nothing."),
new DialogueLine("Yeonhee", "Uh… when do we eat?"),
new DialogueLine("Cheonmi", " We didn’t do well today."),
new DialogueLine("Yeonhee", "What does that have to do with anything?"),
new DialogueLine("Yeonseo", " It means the manager doesn’t get us dinner."),
new DialogueLine(" ", "What? That’s insane. Xuan Mo looks like she’s about to pass out… everyone worked so hard… and they punish us with food?"),
new DialogueLine("Yeonhee", "How is that allowed?"),
new DialogueLine("Xuan Mo", " It’s allowed. It’s in the contract."),
new DialogueLine(" ", "Oh… I didn’t read that."),
new DialogueLine("Yeonseo", " Yeonhee, do you still have your snacks?"),
new DialogueLine("Yeonhee", "Yeah, I do. We can eat that for dinner."),
new DialogueLine(" ", "Rose and Yeonseo light up immediately."),
new DialogueLine(" ", "Good thing I didn’t throw them away…"),
new DialogueLine("Cheonmi", " We’ll survive without food. We always do."),
new DialogueLine(" ", "Always…?"),
new DialogueLine("Cheonmi", " I’m not eating that junk."),
new DialogueLine("Yeonseo", " That’s great then. More for us."),
new DialogueLine("Xuan Mo", " I won’t eat it either."),
new DialogueLine("Rose", " You need to gain weight. Did you not hear what the manager said today?"),
new DialogueLine(" ", "The room goes tense again."),
new DialogueLine("Yeonhee", "My mom didn’t pack that much… we’ll share the tteokbokki and each get a bit of bibimbap."),
new DialogueLine("Rose", " Ouu, I’m so hungry… let’s eat."),
new DialogueLine(" ", "Cheomni rolls her eyes and leaves for the practice room."),
new DialogueLine(" ", "I won’t be having these snacks every day…"),
new DialogueLine(" ", "I guess this really is my life now… I need to work harder."),
new DialogueLine("Yeonseo", " Hmm… this is so good. I haven’t had this kind of food in a while."),
new DialogueLine("Xuan Mo", " Yeah…"),
new DialogueLine("Yeonhee", "What do you guys usually eat?"),
new DialogueLine(" ", "Everyone goes silent."),
new DialogueLine(" ", "Do these people even eat…?"),
new DialogueLine("Yeonseo", " When you see your mom again, tell her we said thank you. Xuan Mo nods."),
new DialogueLine("Rose", " Yeah, it was really good… but we need to get rid of the evidence."),
new DialogueLine("Yeonhee", "Why?"),
new DialogueLine("Rose", " He shouldn’t know we ate without his permission."),
new DialogueLine("Yeonhee", "Huh?"),
new DialogueLine("Yeonseo", " Let’s just throw this out and go to sleep."),
new DialogueLine(" ", "We clean everything up together. It makes me uneasy… Why do I have to hide the fact that I ate?"),
new DialogueLine(" ", "After that, Rose and Xuan Mo head to the gym to burn it off… which is honestly kind of crazy."),
new DialogueLine(" ", "Yeonseo goes straight to bed. I follow."),

//DORM ROOM
new DialogueLine(" ", "notification from tablet"),
new DialogueLine("Yeonhee", "What’s that…?"),
new DialogueLine(" ", "I glance at the tablet"),
new DialogueLine("Yeonhee", "Oh… I got a message."),
new DialogueLine(" ", "Anonymous: Leave while you still can."),
new DialogueLine("Yeonhee", "“Leave while you still can?"),
new DialogueLine(" ", "Lol… What a childish way to scare competition. I’m going to sleep. …but what if…"),
new DialogueLine(" ", "Ugh… never mind."),

//Cheomni's bad side branch2
//[Gained bad points during the challenge]

//PRACTICE ROOM
new DialogueLine(" ", "My heart is pounding… that was so difficult."),
new DialogueLine(" ", "I can’t believe I did so terribly, I really thought I would get the hang of it immediately. Everyone sounded so good, even with their mistakes… and then you get me."),
new DialogueLine(" ", "I really need to work on my vocals. Rose sounded amazing, it was like hearing an angel sing."),
new DialogueLine(" ", "All the girls sit together on the couch while the manager and trainer talk on the other side of the room."),
new DialogueLine(" ", "I wonder what they’re saying about me… the trainer keeps looking my way. I hope they don’t kick me out, I wouldn’t blame them if they did."),
new DialogueLine(" ", "But to my surprise, Cheomni is sitting alone on the other side of the room. She glances at me, then looks back at the wall."),
new DialogueLine(" ", "Something about that glance… It makes me feel uncomfortable. But maybe I’m just overthinking it."),
new DialogueLine(" ", "That challenge was intense. What made the situation worse was the trainer yelling at everyone… he’s not as chill as I thought he’d be."),
new DialogueLine(" ", "I feel really bad for Xuan Mo though… he wouldn’t get off her back. Maybe I should check on her."),
new DialogueLine("Yeonhee", "Hey Xuan Mo, are you okay? You’re sweating a lot."),
new DialogueLine(" ", "Xuan Mo looks at me and sighs."),
new DialogueLine("Xuan Mo", " I’m fine."),
new DialogueLine("Yeonhee", "Okay… I was just worried. You seem a bit out of it right now."),
new DialogueLine("Xuan Mo", " You should worry about yourself here."),
new DialogueLine(" ", "Well damn… I guess this is why nobody talks to her. She makes it really difficult… but I’ll still try."),
new DialogueLine("Cheonmi", " Leave her. She’s always like this."),
new DialogueLine(" ", "The room goes quiet."),
new DialogueLine(" ", "Cheomni stares at me before speaking, like she’s choosing her words."),
new DialogueLine("Cheonmi", " Your performance was questionable, but I guess it wasn’t that bad… That didn’t feel like a compliment…"),
new DialogueLine("Yeonhee", "Haahh… thanks."),
new DialogueLine("Manager", " So much chatter coming from you, Yeonhee. You should get rid of that habit."),
new DialogueLine(" ", "Again… Why is it always me?"),
new DialogueLine(" ", "At least he broke the silence…"),
new DialogueLine("Yeonhee", "Sorry…"),
new DialogueLine("Trainer", " Let’s discuss today’s session. It seems we’ve been too soft on some of you… I don’t know what happened, but today’s performance was absolutely ridiculous."),
new DialogueLine(" ", "The room goes tense."),
new DialogueLine("Trainer", " Yeonhee, your voice… work on it. It sounds childish. I asked for cute, not toddler. And what’s up with you forgetting a simple lyric? If you want to continue in this company, pull up your socks. I don’t want to talk about this ridiculous performance next time. I’ll create a separate schedule for you to practice outside of training hours. You need it."),
new DialogueLine(" ", "Cheomni laughs softly."),
new DialogueLine(" ", "What’s her deal anyway?"),
new DialogueLine(" ", "This is actually so embarrassing… he didn’t have to be that harsh."),
new DialogueLine("Trainer", " Xuan Mo, forgetting lyrics again. Have you even been attending your language classes? Your Korean sounds choppy."),
new DialogueLine(" ", "Xuan Mo keeps the same expressionless look she always has."),
new DialogueLine("Trainer", " Rose, your voice is too powerful. If you want to be a solo artist, then leave. Stop trying to outshine everyone. At least your Korean is understandable."),
new DialogueLine(" ", "Rose looks down quietly."),
new DialogueLine("Trainer", " Yeonseo, you were good. Just fix the voice cracks."),
new DialogueLine("Yeonseo", " Thank you, sir!"),
new DialogueLine(" ", "The trainer pauses, then looks at Cheomni."),
new DialogueLine(" ", "As bad as it sounds, I actually can’t wait for her to get scolded. She’s been on her high horse since I got here… and she made the most mistakes out of everyone."),
new DialogueLine("Trainer", " Cheomni, perfect as always. Just work on remembering your lyrics without stuttering."),
new DialogueLine(" ", "What? That’s not fair… she messed up the most."),
new DialogueLine("Trainer", " Evaluations are over. Fix what I told you. I don’t want to hear these mistakes again."),
new DialogueLine(" ", "He leaves."),
new DialogueLine(" ", "The room finally feels lighter."),
new DialogueLine("Manager", " Good job, girls. We just need more practice. See you tomorrow."),
new DialogueLine(" ", "He looks calm… but I can literally see a vein popping on his forehead. What’s wrong with him?"),

//COMPANY LOBBY
new DialogueLine(" ", "We all start heading back to the dorm."),
new DialogueLine(" ", "Rose wraps her arm around mine while Yeonseo walks beside me. It feels like we’re forming a closer bond… It makes today feel a little less torturous."),
new DialogueLine("Rose", " Well… I guess we’re sleeping early today."),
new DialogueLine("Yeonhee", "Why?"),
new DialogueLine("Yeonseo", " You’ll see."),
new DialogueLine(" ", "I can’t stop thinking about Rose’s voice… I barely even hear the conversation."),
new DialogueLine("Yeonhee", "Uh… Rose… I think you have a really beautiful voice. I want to sing like you someday."),
new DialogueLine(" ", "Rose smiles softly, but before she can reply"),
new DialogueLine("Cheonmi", " Your opinion doesn’t really matter here. If you want to succeed, listen to the trainers… not Rose."),
new DialogueLine("Yeonseo", " I guess that didn’t work out for you today though."),
new DialogueLine(" ", "Cheomni’s expression tightens, but she says nothing and walks ahead. There’s so much tension here…"),

//DORM
new DialogueLine(" ", "Back at the dorm, everyone gathers around to check their scoreboards."),

//Score of the day:
//1.Cheomni
//2.Yeonseo
//3.Kandy
//4.Minjii
//5.Rose
//6.Mei
//7.Xuan Mo
//8.Yeonhee

new DialogueLine(" ", "My score remained the same… this is so disheartening. I really need to work harder. Rose moved up two tiers. Just a few hours ago we were right next to each other."),
new DialogueLine("Rose", " Don’t worry about the scores today, you did your best."),
new DialogueLine(" ", "That’s easy for you to say…"),
new DialogueLine("Yeonhee", "Thank you."),
new DialogueLine(" ", "Despite everything, I’m actually proud of myself for making it through the challenge… even if my evaluation was bad. I can’t wait to see what tomorrow brings."),
new DialogueLine(" ", "But first… I need food. I’m starving."),

//DORM KITCHEN
new DialogueLine(" ", "I walk into the kitchen."),
new DialogueLine(" ", "Nothing."),
new DialogueLine("Yeonhee", "Uh… when do we eat?"),
new DialogueLine("Cheonmi", " We didn’t do well today."),
new DialogueLine("Yeonhee", "What does that have to do with anything?"),
new DialogueLine("Yeonseo", " It means the manager doesn’t get us dinner."),
new DialogueLine(" ", "What ? That’s insane.Xuan Mo looks like she’s about to pass out… everyone worked so hard, and they punish us with food?"),
new DialogueLine("Yeonhee", "How is that allowed?"),
new DialogueLine("Xuan Mo", " It’s allowed. They wrote it in the contract."),
new DialogueLine(" ", "Oh… I didn’t read that."),
new DialogueLine("Yeonseo", " Yeonhee, do you still have your snacks?"),
new DialogueLine("Yeonhee", "Yeah, I do. We can eat that for dinner."),
new DialogueLine(" ", "Rose and Yeonseo light up."),
new DialogueLine(" ", "Now imagine if I threw my snacks away."),
new DialogueLine("Cheonmi", " We’ll survive without food. We always do."),
new DialogueLine(" ", "Always…?"),
new DialogueLine("Cheonmi", " I’m not eating that junk."),
new DialogueLine("Yeonseo", " That’s great then, more for us."),
new DialogueLine("Xuan Mo", " I won’t eat it either."),
new DialogueLine("Rose", " You need to gain weight. Did you not hear what the manager said today? The room goes tense again."),
new DialogueLine("Yeonhee", "My mom didn’t pack that much… we’ll just share the tteokbokki and have one bibimbap each."),
new DialogueLine("Rose", " Ouu, I’m so hungry… let’s eat."),
new DialogueLine(" ", "Cheomni rolls her eyes and goes back to bed."),
new DialogueLine(" ", "I won’t be having these snacks every day."),
new DialogueLine(" ", "I guess this really is my life now… I need to work harder."),
new DialogueLine("Yeonseo", " This is actually so good… I haven’t had food like this in a while."),
new DialogueLine("Xuan Mo", " Yeah…"),
new DialogueLine("Yeonhee", "What do you guys usually eat?"),
new DialogueLine(" ", "Everyone goes silent."),
new DialogueLine(" ", "Do these people even eat?"),
new DialogueLine("Yeonseo", " When you see your mom again, tell her we said thank you for the snacks. Xuan Mo nods."),
new DialogueLine("Rose", " Yeah, they were really good… but we need to get rid of the evidence."),
new DialogueLine("Yeonhee", "Why?"),
new DialogueLine("Rose", " He shouldn’t know that we ate without his permission."),
new DialogueLine("Yeonhee", "Huh?"),
new DialogueLine("Yeonseo", " Let’s just throw it out once we’re done and go to sleep."),
new DialogueLine(" ", "We all help each other clean up and throw everything away. It makes me feel uneasy… Why do I have to hide the fact that I ate?"),
new DialogueLine(" ", "After that, Rose and Xuan Mo go to the gym to burn off the food, which I actually find kind of funny."),
new DialogueLine(" ", "Yeonseo goes straight to bed. I follow her."),

//DORM ROOM
new DialogueLine(" ", "notification from tablet "),
new DialogueLine("Yeonhee", "What’s that…?"),
new DialogueLine(" ", "I glance at the tablet."),
new DialogueLine("Yeonhee", "Oh… I got a message."),
new DialogueLine(" ", "Anonymous: Leave while you still can."),
new DialogueLine("Yeonhee", "Leave while you still can?"),
new DialogueLine(" ", "Lol… What a childish way to scare competition. I’m going to sleep. …but what if…"),
new DialogueLine(" ", "Ugh… never mind.")
        };

        index = 0;
        ShowLine();
    }

    void Update()
    {
        if (isChoosing) return; // BLOCK SPACE INPUT

        if (Keyboard.current != null &&
            Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            NextLine();
        }
    }

    void ShowLine()
    {
        if (ui == null)
        {
            Debug.LogError("UI is not assigned in Chapter1!");
            return;
        }

        if (dialogueLines == null || dialogueLines.Length == 0)
        {
            Debug.LogError("DialogueLines is empty!");
            return;
        }

        if (index < 0 || index >= dialogueLines.Length)
        {
            Debug.Log("End reached.");
            return;
        }

        var line = dialogueLines[index];

        if (line == null)
        {
            Debug.LogError("DialogueLine is null at index: " + index);
            return;
        }

        ui.ShowLine(line.characterName, line.dialogueText);
    }

    public void NextLine()
    {
        var line = dialogueLines[index];

        if (line.hasChoices && line.choices != null && line.choices.Length > 0)
        {
            isChoosing = true;
            ui.ShowChoices(line.choices);
            return;
        }

        index++;
        ShowLine();
    }

    public void OnChoiceSelected(DialogueChoice choice)
    {
        ui.ClearChoices(); // hide panel
        index = choice.nextLineIndex;
        ShowLine();
    }
}
