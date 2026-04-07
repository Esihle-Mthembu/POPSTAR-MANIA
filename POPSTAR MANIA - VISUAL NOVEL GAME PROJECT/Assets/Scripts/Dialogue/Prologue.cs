using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueLine
{
    public string characterName;
    [TextArea(2, 5)]
    public string line;

    public DialogueLine(string name, string text)
    {
        characterName = name;
        line = text;
    }
}

public class Prologue : MonoBehaviour
{
    // UI fields
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    // Dialogue data stored in an array of DialogueLine
    private DialogueLine[] dialogueLines;

    private int index = 0;
    
    private int currentLine;

    void Start()
    {
        // Assign lines directly in the script
        dialogueLines = new DialogueLine[]
        {
        new DialogueLine("Yeonhee", "Hi, I’m Lim Yeonhee."),
        new DialogueLine("Yeonhee", "Your average student at Joesei Secondary school."),
        new DialogueLine("Yeonhee", "I’m in my third year of high school, which has been a little bit hectic but fun."),
        new DialogueLine("Yeonhee", "My study stream is Humanities, which my parents hated. They wanted me to become something “reputable”, but I don’t really care about people’s opinions that much."),
        new DialogueLine("Yeonhee", "OH I nearly forgot..."),
        new DialogueLine("Yeonhee", "I’m what you call a die hard kpop fan, but don’t worry I'm not a Sasaeng. I just really love K- pop."),
        new DialogueLine("Yeonhee", "I love the glitz and glamour around it, and I love watching Idols live their day to day lives."),
        new DialogueLine("Yeonhee", "Sometimes it makes me wonder what my life would look like if I were a K - pop idol.If I had the opportunity to become one,.I’d immediately take it. no questions asked."),
        new DialogueLine("Yeonhee", "I just didn’t expect that chance would come so soon"),
        new DialogueLine("Yeonhee", "...anyways."),
        new DialogueLine("Yeonhee", "I think their life is so much cooler compared to mine."),
        new DialogueLine("Yeonhee", "It's not like I don't have any talent either.so I'd fit into the idol world pretty well"),
        new DialogueLine("Yeonhee", "...and maybe I'll finally get to talk to my lovely Joon."),
        new DialogueLine("Yeonhee", "Sigh"),
        new DialogueLine("Yeonhee", "My everyday routine always starts the same way.I arrive at school about fifteen minutes before class starts and meet up with my friends to talk about posts from thenight before."),
        new DialogueLine("Yeonhee", "Heyyy."),
        new DialogueLine("", "Everyone greets Yeonhee back and the three of them sit close together, with their phones out in the middle."),
        new DialogueLine("Friend 1", "Did you see the post about Starlight’s new girl group?"),
        new DialogueLine("Friend 2", "Oh my God yes I did.All of the girls looked so young, I was confused."),
        new DialogueLine("Friend 1", "Literally the oldest one in the group is thirteen years old."),
        new DialogueLine("Yeonhee", "I saw that too, but their concept actually looks really cool."),
        new DialogueLine("Friend 1", "That still doesn’t take away from the fact that they’re probably getting exploited."),
        new DialogueLine("", "Yeonhee shrugs slightly."),
        new DialogueLine("Yeonhee", "I guess so..."),
        new DialogueLine("", "She suddenly pushes her phone toward them."),
        new DialogueLine("Yeonhee", "Anyways, did you see Joon's post? Oh my gee he’s so freaking hot."),
        new DialogueLine("", "Friend 1 side-eyes her."),
        new DialogueLine("Friend 1", "Right??"),
        new DialogueLine("Friend 2", "laughs."),
        new DialogueLine("Friend 2", "His post was low-key hot. He’s finally comfortable showing his abs."),
        new DialogueLine("", "Yeonhee grins."),
        new DialogueLine("Yeonhee","I love that for him.I’m excited for their new vampire concept too."),
        new DialogueLine("", "She leans back in her chair."),
        new DialogueLine("Yeonhee", "I actually can’t wait to debut. Joon and I definitely have ke-mi."),
        new DialogueLine("", "Friend 1 rolls their eyes."),
        new DialogueLine("Friend 1", "Delusionalll.Anyways, sir’s coming."),
        new DialogueLine("", "Yeonhee groans."),
        new DialogueLine("Yeonhee", "Why is he never late or absent?"),
        new DialogueLine("", "The teacher walks into the classroom."),
        new DialogueLine("Teacher", "Everyone go back to your seats and take out your books please."),
        new DialogueLine("", "The class slowly moves back to their desks."),
        new DialogueLine("Teacher", "I only want to see Art History books on the table.No maths, no English, or anything related to another subject."),
        new DialogueLine("", "The class sighs loudly."),
        new DialogueLine("", "Yeonhee mutters under her breath."),
        new DialogueLine("Yeonhee", "I swear it’s always something."),
        new DialogueLine("", "The teacher pulls up the next slide on the TV."),
        new DialogueLine("Teacher", "Now that we’ve got that out of the way, let’s discuss today’s painting. This one is very important because you’ll be writing an essay on it during your CSAT’s. Don’t say I didn’t warn you."),
        new DialogueLine("", "The slide changes."),
        new DialogueLine("Teacher", "The painting of the day is The Painter’s Studio:A Real Allegory Summing Up Seven Years of My Life as an Artist by Gustave Courbet, dated 1855."),
        new DialogueLine("", "He looks around the room."),
        new DialogueLine("Teacher", "Fun fact. This painting was rejected from a national exhibition. Why do you think that was?"),
        new DialogueLine("", "The teacher scans the room and stops when Friend 1 raises their hand."),
        new DialogueLine("Teacher", "Yes?"),
        new DialogueLine("Friend 1", "Because people hate seeing the truth."),
        new DialogueLine("", "Teacher nods."),
        new DialogueLine("Teacher", "Correct.People are often blinded by power once they get a taste of it."),
        new DialogueLine("", "He gestures toward the painting."),
        new DialogueLine("Teacher", "The left side shows the exploited, and the right side shows the exploiters. The painter stands in the middle observing both sides."),
        new DialogueLine("", "Yeonhee glances at the painting for a moment before looking back down at her laptop."),
        new DialogueLine("", "She scrolls through Instagram posts about Starlight's new girl group instead."),
        new DialogueLine("", "Minutes pass."),
        new DialogueLine("Teacher", "I want all of you to go home and sit with this painting.Think about what it means to you personally. We’ll discuss it in the next class."),
        new DialogueLine("", "The bell rings."),
        new DialogueLine("", "Yeonhee stretches."),
        new DialogueLine("Yeonhee", "Heol, that session took forever to end."),
        new DialogueLine("Friend 1", "He just wouldn’t stop talking."),
        new DialogueLine("Friend 2", "The fact that we even have to write an exam on this... you’re definitely going to fail, Yoenh.You didn’t even pay attention today."),
        new DialogueLine("", "Yeonhee shrugs."),
        new DialogueLine("Yeonhee", "It’s fine. I heard everything he said.Besides, I don’t think..."),
        new DialogueLine("Teacher", "Okay class."),
        new DialogueLine("", "The teacher interrupts."),
        new DialogueLine("Teacher", "I’m giving you this half period to study for your next assignment.No chatting."),
        new DialogueLine("", "His eyes narrow and land directly on Yeonhee."),
        new DialogueLine("", "The class giggles."),
        new DialogueLine("", "Yeonhee quickly looks down at her laptop, cheeks warm with embarrassment."),
        new DialogueLine("", "Instead of looking at her notes, she opens Instagram."),
        new DialogueLine("", "leans over slightly."),
        new DialogueLine("Friend 1", "What are you doing? It’s our study period."),
        new DialogueLine("", "Friend 2 laughs."),
        new DialogueLine("Friend 2", "She’s probably looking at K-pop idols again."),
        new DialogueLine("", "They look at her screen."),
        new DialogueLine("Friend 2", "Called it."),
        new DialogueLine("", "Before Yeonhee can respond, a pop-up advertisement appears."),
        new DialogueLine("", "FIND YOUR DREAM AT DIAMON ENT! GLOBAL AUDITIONS OPEN NOW. LOOKING FOR THE NEXT MEMBER OF A 4-MEMBER GIRL GROUP"),
        new DialogueLine("", "All three of them stare at the screen."),
        new DialogueLine("Friend 1", "Is this real?"),
        new DialogueLine("", "Friend 2 shakes her head."),
        new DialogueLine("Friend 2", "It has to be fake."),
        new DialogueLine("", "Yeonhee’s heart starts beating faster."),
        new DialogueLine("Yeonhee", "This is destiny."),
        new DialogueLine("", "Friend 1 immediately shakes her head."),
        new DialogueLine("Friend 1", "No, it’s not. Don’t do something dumb."),
        new DialogueLine("Friend 2", "It’s probably a scam."),
        new DialogueLine("", "Yeonhee lowers her voice but speaks aggressively."),
        new DialogueLine("Yeonhee", "It’s not. Look, there’s an address and a number. It’s a real company."),
        new DialogueLine("", "Her eyes shine with excitement."),
        new DialogueLine("Yeonhee", "I’m going to audition this Saturday.I’m going to become an idol."),
        new DialogueLine("", "Friend 1 and Friend 2 exchange worried looks."),
        new DialogueLine("Friend 2", "We really don’t think you should."),
        new DialogueLine("Teacher", "GIRLS!"),
        new DialogueLine("", "The teacher snaps loudly."),
        new DialogueLine("Teacher", "Do I have to separate you again?"),
        new DialogueLine("", "Yeonhee sits up immediately."),
        new DialogueLine("Yeonhee", "Sorry sir. I was just showing them a source for their essays."),
        new DialogueLine("", "The teacher stares at her for a moment."),
        new DialogueLine("Teacher", "Yeonhee.the teacher sighed, tapping his pen against the desk. If you spent half as much time studying as you do staring at K-pop idols, you might actually reach the first position in this class."),
        new DialogueLine("", "Yeonhee paused, then slowly closed her laptop and opened her textbook."),
        new DialogueLine("Teacher", "This is your last warning."),
        new DialogueLine("", "The car ride home is quieter than usual."),
        new DialogueLine("", "Yeonhee sits in the back seat while traffic slowly moves forward. The commute normally takes about thirty minutes, but during this time of day it can take almost fifty."),
        new DialogueLine("", "She sighs quietly."),
        new DialogueLine("", "Dad notices."),
        new DialogueLine("Dad", "You’re awfully quiet today. What happened at school?"),
        new DialogueLine("", "Mom smiles slightly."),
        new DialogueLine("Mom", "Yeah, why aren’t you complaining about how awful your art history teacher is?"),
        new DialogueLine("", "Yeonhee hesitates before speaking."),
        new DialogueLine("Yeonhee", "I just have something I’ve been meaning to tell you."),
        new DialogueLine("", "Dad sighs."),
        new DialogueLine("Dad", "What is it now, Yeonhee?"),
        new DialogueLine("", "Mom gently nudges him."),
        new DialogueLine("Mom", "Calm down. Let her talk."),
        new DialogueLine("", "Yeonhee takes a breath."),
        new DialogueLine("Yeonhee", "Well...I saw this Instagram post about auditions for a new K-pop girl group this weekend...and I was wondering if I could try out."),
        new DialogueLine("Dad", "WHAT?"),
        new DialogueLine("", "Yeonhee immediately looks down at her legs."),
        new DialogueLine("Dad", "A K-pop group? You’ve finally lost it, Lim Yeonhee."),
        new DialogueLine("Mom", "Why do you want to become an idol? Can't you focus on school and your art?"),
        new DialogueLine("Yeonhee", "I can still do that if it doesn’t work out. Please, Mom."),
        new DialogueLine("", "Dad shakes his head immediately."),
        new DialogueLine("Dad", "No.Absolutely not. The industry is not good for you and I’m not letting you throw your future away."),
        new DialogueLine("", "Yeonhee’s voice becomes more desperate."),
        new DialogueLine("Yeonhee", "I’m not throwing anything away.I’ll still study.I promise."),
        new DialogueLine("Dad", "No means no."),
        new DialogueLine("", "The car becomes quiet for a moment."),
        new DialogueLine("", "Mom glances at Yeonhee through the mirror.She can see how nervous and excited she looks."),
        new DialogueLine("Mom", "Maybe...we should at least let her try."),
        new DialogueLine("", "Dad looks at her in disbelief."),
        new DialogueLine("Dad", "Try? You know how those companies are."),
        new DialogueLine("Mom", "It’s just an audition."),
        new DialogueLine("Dad", "And if they accept her?"),
        new DialogueLine("", "Mom hesitates for a moment before speaking."),
        new DialogueLine("Mom", "Then we deal with it when the time comes."),
        new DialogueLine("", "Dad sighs heavily."),
        new DialogueLine("Dad", "I don’t like this at all."),
        new DialogueLine("", "Mom turns slightly in her seat."),
        new DialogueLine("Mom", "Yeonhee, you can go to the audition."),
        new DialogueLine("", "Yeonhee’s eyes widen."),
        new DialogueLine("Mom", "But if this starts affecting school, it stops immediately."),
        new DialogueLine("", "Yeonhee nods quickly."),
        new DialogueLine("Yeonhee", "I promise."),
        new DialogueLine("", "Dad keeps his eyes on the road."),
        new DialogueLine("Dad", "I’m still not okay with this."),
        new DialogueLine("", "Yeonhee looks out the window, trying to hide her smile"),
        new DialogueLine("", "Two mornings later"),
        new DialogueLine("Mom", "Yeonhee, wake up...you’re going to be late."),
        new DialogueLine("", "Yeonhee doesn’t answer."),
        new DialogueLine("", "Mom rushes down the hallway to Yeonhee’s bedroom."),
        new DialogueLine("Mom", "YEONHEE, WAKE UP! she barges into the room to find Yeonhee already dressed."),
        new DialogueLine("Yeonhee", "Morning Ma, i’m coming down now, just putting on my shoes."),
        new DialogueLine("Mom", "Wow okay... uhh I made you breakfast and I packed a few snacks you can share with your new friends."),
        new DialogueLine("", "Yeonhee goes down downstairs, passes her dad in the kitchen and hugs him goodbye."),
        new DialogueLine("", "On the way to the company her stomach dropped to her feet, the feeling of auditioning became more realistic as she saw how close she was to the company."),
        new DialogueLine("", "When they arrived she noticed how eerie the company looked, everything about it seemed sketchy."),
        new DialogueLine("", "The company was smaller than she expected."),
        new DialogueLine("", "And the paint was peeling off as if it was an old company building."),
        new DialogueLine("", "Mom looks uncertain."),
        new DialogueLine("Mom", "Is this the right place?"),
        new DialogueLine("", "Yeonhee studies the building."),
        new DialogueLine("Yeonhee", "I think so."),
        new DialogueLine("", "She steps out of the car."),
        new DialogueLine("", "Her stomach twists with nervous excitement as she walks toward the entrance."),
        new DialogueLine("", "Inside, the building is strangely quiet."),
        new DialogueLine("", "A recruiter sits at the front desk."),
        new DialogueLine("Recruiter", "You must be Lim Yeonhee."),
        new DialogueLine("", "Yeonhee bows quickly."),
        new DialogueLine("Yeonhee", "Yes."),
        new DialogueLine("", "The recruiter smiles politely."),
        new DialogueLine("Recruiter", "Come this way.I’ll take you to the boardroom."),
        new DialogueLine("", "As they walk down the hallway, Yeonhee notices something strange."),
        new DialogueLine("", "The building looked unusually empty."),
        new DialogueLine("", "Why am I the only one auditioning today? she wonders."),
        new DialogueLine("", "The recruiter opens a large door."),
        new DialogueLine("", "Inside sit three people."),
        new DialogueLine("", "The CEO and two panel members."),
        new DialogueLine("", "Yeonhee stood alone in the center of the room while the CEO and the panel members watched from the other side of the table."),
        new DialogueLine("", "For some reason it reminded her of the painting from class earlier."),
        new DialogueLine("", "Yeonhee bows until her head touches her knees."),
        new DialogueLine("Yeonhee", "Hi! I’m Yeonhee and I can sing and dance and..."),
        new DialogueLine("", "The CEO suddenly laughs loudly."),
        new DialogueLine("", "Yeonhee stops talking."),
        new DialogueLine("Yeonhee", "I can’t tell if that was a good sign or a bad one."),
        new DialogueLine("", "Panel Member 2 smiles at her."),
        new DialogueLine("Panel Member 2", "Don’t worry. We already know who you are from your portfolio."),
        new DialogueLine("CEO", "Welcome, Yeonhee.We found your profile quite interesting."),
        new DialogueLine("", "Panel Member 1 slides a contract across the table."),
        new DialogueLine("Panel Member 1", "In this company we’re looking for people who are willing to dedicate their time to perfecting their craft."),
        new DialogueLine("Panel Member 2", "Not fans chasing fantasies."),
        new DialogueLine("", "Yeonhee straightens confidently."),
        new DialogueLine("Yeonhee", "I’m in the top ten of my entire grade.I’m determined in anything I do."),
        new DialogueLine("", "She bows again."),
        new DialogueLine("Yeonhee", "Please take me in."),
        new DialogueLine("", "The CEO laughs again."),
        new DialogueLine("CEO", "Welcome to the company, Yeonhee."),
        new DialogueLine("", "Yeonhee blinks in confusion."),
        new DialogueLine("Yeonhee", "What? Just like that? I didn’t even audition."),
        new DialogueLine("", "Panel Member 2 smiles."),
        new DialogueLine("Panel Member 2", "That was the audition."),
        new DialogueLine("", "The contract sits in front of her."),
        new DialogueLine("", "Panel Member 1 taps the paper."),
        new DialogueLine("Panel Member 1", "Sign this and the deal is done."),
        new DialogueLine("", "Yeonhee hesitates for a moment."),
        new DialogueLine("", "Something in the back of her mind tells her she should read it first."),
        new DialogueLine("", "But she’s too excited to think about it."),
        new DialogueLine("", "She signs the contract."),
        new DialogueLine("", "The CEO smiles."),
        new DialogueLine("", "Yeonhee stands and bows happily."),
        new DialogueLine("", "Her dream is finally starting."),
        new DialogueLine("", "As she leaves the room, she hears one of the panel members whisper quietly behind her."),
        new DialogueLine("", "“Another one signed.”"),
        new DialogueLine("", "Yeonhee pauses for a second."),
        new DialogueLine("", "But she quickly shakes the thought away."),
        new DialogueLine("", "All she can think about is her debut.")
        };

        ShowNextLine();
    }

    void Update()
    {
        if ((Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame) ||
            (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame))
        {
            ShowNextLine();
        }
    }

    void NextLine()
    {
        currentLine++;

        PlayerPrefs.SetString("LastScene", "Prologue");
        PlayerPrefs.SetInt("DialogueIndex", currentLine);
        PlayerPrefs.Save();

        ShowNextLine();
    }

    void ShowNextLine()
    {
        if (index >= dialogueLines.Length)
        {
            dialogueText.text = "End of Prologue";
            nameText.text = "";
            return;
        }

        dialogueText.text = dialogueLines[index].line;

        // If character name is empty → hide name
        if (string.IsNullOrEmpty(dialogueLines[index].characterName))
        {
            nameText.text = "";  // no name shown
        }
        else
        {
            nameText.text = dialogueLines[index].characterName;
        }

        index++;
    }
}
