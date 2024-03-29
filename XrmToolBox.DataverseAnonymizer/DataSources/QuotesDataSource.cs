﻿using System;

namespace XrmToolBox.DataverseAnonymizer.DataSources
{
    public class QuotesDataSource
    {
        private static Random random = new Random();

        private static string[] quotes = new string[]
        {
            "The greatest adventure is the one you create in your mind.",
            "Success is not a destination, but a journey of persistence and determination.",
            "In the silence of solitude, one finds the strength to roar like a lion.",
            "Love is the music of the soul, playing the symphony of eternity.",
            "The path to wisdom is paved with humility and curiosity.",
            "Every sunset whispers secrets of hope to the heart that listens.",
            "Life's canvas is painted with the colors of our choices.",
            "In the garden of life, kindness is the most beautiful flower.",
            "Dreams are the blueprints of tomorrow, waiting for us to build.",
            "Storms make the oak tree stronger, and challenges make the spirit resilient.",
            "Happiness is not found in possessions but in moments of gratitude.",
            "The wings of imagination carry us to the horizons of possibility.",
            "In the dance of time, let your steps leave imprints of joy.",
            "Stars shine brightest in the darkest of nights.",
            "Courage is the compass that guides us through the wilderness of fear.",
            "Life's greatest treasures are hidden in the depths of the heart.",
            "The melody of life is composed of both highs and lows.",
            "In the symphony of existence, every note has its purpose.",
            "The fire within you burns brighter than the stars above.",
            "The echo of laughter reverberates through the corridors of eternity.",
            "Hope is the lighthouse that guides ships through the storms of despair.",
            "Every ending is a new beginning waiting to unfold.",
            "The journey of a thousand miles begins with a single step of faith.",
            "Kindness is the language that the deaf can hear and the blind can see.",
            "The power of forgiveness sets the spirit free.",
            "In the tapestry of life, every thread weaves a story of resilience.",
            "The whispers of the wind carry the secrets of the universe.",
            "With each sunrise comes the promise of a new beginning.",
            "The dance of life is choreographed by the rhythm of the heart.",
            "In the garden of dreams, faith is the seed that blossoms into reality.",
            "The wings of hope lift us above the storms of adversity.",
            "The fragrance of kindness lingers long after the bloom has faded.",
            "Embrace the storms of life, for they cleanse the spirit and nourish the soul.",
            "In the silence of solitude, the soul finds its true voice.",
            "Challenges are the stepping stones to greatness.",
            "The tapestry of life is woven with threads of love and compassion.",
            "The stars may guide us, but it is our choices that shape our destiny.",
            "In the garden of life, gratitude is the seed of abundance.",
            "The symphony of existence plays on, regardless of the conductor.",
            "The whispers of the past echo in the chambers of memory.",
            "With each step forward, the horizon of possibility expands.",
            "Courage is not the absence of fear, but the triumph over it.",
            "The melody of life is composed of both sorrow and joy.",
            "The heart's journey is guided by the compass of love.",
            "In the silence of nature, the soul finds solace.",
            "Every ending is a new beginning in disguise.",
            "The stars may be distant, but their light shines within us all.",
            "Dreams are the blueprints of the soul's desires.",
            "The dance of life is a symphony of possibility.",
            "The whispers of the wind carry the dreams of tomorrow.",
            "Kindness is the language of the heart, spoken by all.",
            "In the garden of dreams, courage is the seed that blooms into destiny.",
            "The rhythm of life beats in time with the heart's desires.",
            "Every sunset is a reminder that endings can be beautiful too.",
            "The symphony of existence is written in the language of the soul.",
            "With each dawn comes the promise of a new beginning.",
            "In the tapestry of life, every thread has its purpose.",
            "The fragrance of kindness perfumes the air with love.",
            "The fire within you burns brighter than the stars above.",
            "The echoes of laughter linger in the halls of memory.",
            "Every storm runs out of rain, and every night turns into day.",
            "The whispers of the past carry the wisdom of ages.",
            "In the silence of solitude, the soul finds sanctuary.",
            "Challenges are the stepping stones to wisdom.",
            "The tapestry of life is woven with threads of courage and resilience.",
            "The stars may guide us, but it is our choices that shape our destiny.",
            "In the garden of life, gratitude is the seed of abundance.",
            "The symphony of existence plays on, regardless of the conductor.",
            "The whispers of the past echo in the chambers of memory.",
            "With each step forward, the horizon of possibility expands.",
            "Courage is not the absence of fear, but the triumph over it.",
            "The melody of life is composed of both sorrow and joy.",
            "The heart's journey is guided by the compass of love.",
            "In the silence of nature, the soul finds solace.",
            "Every ending is a new beginning in disguise.",
            "The stars may be distant, but their light shines within us all.",
            "Dreams are the blueprints of the soul's desires.",
            "The dance of life is a symphony of possibility.",
            "The whispers of the wind carry the dreams of tomorrow.",
            "Kindness is the language of the heart, spoken by all.",
            "In the garden of dreams, courage is the seed that blooms into destiny.",
            "The rhythm of life beats in time with the heart's desires.",
            "Every sunset is a reminder that endings can be beautiful too.",
            "The symphony of existence is written in the language of the soul.",
            "With each dawn comes the promise of a new beginning.",
            "In the tapestry of life, every thread has its purpose.",
            "The fragrance of kindness perfumes the air with love.",
            "The fire within you burns brighter than the stars above.",
            "The echoes of laughter linger in the halls of memory.",
            "Every storm runs out of rain, and every night turns into day.",
            "The whispers of the past carry the wisdom of ages.",
            "In the silence of solitude, the soul finds sanctuary.",
            "Challenges are the stepping stones to wisdom.",
            "The tapestry of life is woven with threads of courage and resilience.",
            "Life is like a sandwich - the more you add to it, the better it becomes!",
            "Don't just follow your dreams, chase them down the street in your pajamas!",
            "Success is just a nap away from failure - so keep dreaming big!",
            "If life gives you lemons, make a lemonade stand and sell happiness!",
            "Forget about thinking outside the box - just build a fort with the box!",
            "Why walk when you can skip? Why skip when you can dance? Live life with a groove!",
            "Remember, you're not lost, you're just taking the scenic route to success!",
            "Believe in yourself like a toddler believes in Santa Claus - with unbridled enthusiasm!",
            "If opportunity doesn't knock, build a door and paint it neon pink!",
            "Life is like a video game - level up by embracing the challenges and collecting the power-ups!",
            "Don't wait for the rainbow, be the unicorn that brings color to the world!",
            "Be the pineapple in a world of apples - stand tall, wear a crown, and be sweet on the inside!",
            "Why fit in when you were born to stand out? Embrace your inner disco ball!",
            "If you stumble, make it part of the dance - the cha-cha-cha of life!",
            "Life is too short to wear boring socks - put on your polka dots and let the adventure begin!",
            "Just like a pizza, life is best served with extra cheese and a side of laughter!",
            "Be the pilot of your own hot air balloon - rise above the clouds and enjoy the view!",
            "Don't stress about finding the light at the end of the tunnel - bring your own flashlight and disco ball!",
            "If life throws you curveballs, grab a bat and hit them out of the park!",
            "Embrace your inner goofball - life is too short to be serious all the time!",
            "Dance like nobody's watching, sing like nobody's listening, and live like it's taco Tuesday!",
            "If life hands you a jar of glitter, sprinkle it everywhere and make the world sparkle!",
            "Life is a rollercoaster - strap in, throw your hands in the air, and enjoy the ride!",
            "Don't let fear hold you back - be the superhero of your own story!",
            "Life is a puzzle - don't stress about finding the right pieces, just enjoy putting it together!",
            "If you want to fly, you gotta give up the ground - embrace the sky and spread your wings!",
            "Life is like a buffet - try a little bit of everything and go back for seconds of what you love!",
            "Be the sunshine on a cloudy day - radiate positivity wherever you go!",
            "Why be ordinary when you can be extraordinary? Put on your cape and soar!",
            "Life is a dance party - don't be afraid to break out your best moves!",
            "If life hands you a bag of potatoes, make a mountain of mashed potatoes and invite everyone for dinner!",
            "Don't be a shrinking violet - be a blooming flower and dazzle the world with your petals!",
            "Life is like a box of crayons - embrace all the colors and create a masterpiece!",
            "Don't be afraid to take the scenic route - sometimes the detours lead to the best adventures!",
            "Why walk when you can cartwheel? Life is more fun upside down!",
            "Be the pineapple in a world of coconuts - stand tall, wear a crown, and be sweet on the inside!",
            "If life hands you a bag of lemons, make lemonade and add a splash of glitter!",
            "Life is like a disco ball - it's only dull until you turn on the lights and let it shine!",
            "Don't just dream big, dream unicorn-riding-a-rainbow-into-the-sunset big!",
            "Why be a caterpillar when you can be a butterfly? Spread your wings and fly!",
            "Life is like a trampoline - bounce back higher every time you fall!",
            "If life gives you rain, splash in the puddles and dance in the storm!",
            "Be the firework in a world of sparklers - light up the sky with your brilliance!",
            "Life is too short for boring hair - dye it purple and let your inner wild child out!",
            "Don't just aim for the stars, build a rocket and launch yourself into the galaxy!",
            "Why whisper when you can roar? Let your voice be heard!",
            "Life is like a game of Twister - embrace the chaos and have fun with it!",
            "Be the crayon in a world of black and white - color outside the lines and make your own masterpiece!",
            "If life hands you a pineapple, make pina coladas and have a party!",
            "Why be a piece of the puzzle when you can be the whole picture? Create your own masterpiece!",
            "Life is like a movie - write your own script and make it a blockbuster!",
            "Don't just dream big, dream elephant-riding-a-unicycle-through-space big!",
            "If life gives you bananas, make banana splits and invite everyone to the party!",
            "Be the rainbow in a world of gray skies - bring color wherever you go!",
            "Life is too short for boring adventures - go skydiving in your pajamas!",
            "Why be a caterpillar when you can be a disco-dancing butterfly? Get your groove on!",
            "If life hands you a bag of confetti, throw it in the air and celebrate!",
            "Don't wait for the spotlight, grab a flashlight and make your own stage!",
            "Be the superhero of your own story - cape optional, attitude mandatory!",
            "Life is like a box of chocolates - sweet, unexpected, and best enjoyed with friends!",
            "Why be a fish in a pond when you can be a mermaid in the ocean? Dive deep and dream big!",
            "If life hands you a tuba, play it loud and march to the beat of your own drum!",
            "Don't just climb mountains, build a rollercoaster and ride to the top!",
            "Be the spark in a world of darkness - ignite passion wherever you go!",
            "Life is like a garden - plant seeds of kindness and watch love bloom!",
            "Why be a leaf on the wind when you can be a hurricane? Make waves and leave a splash!",
            "If life hands you a microphone, sing your heart out and serenade the world!",
            "Don't just chase rainbows, be the pot of gold at the end!",
            "Be the pirate of your own ship - chart your own course and sail into the sunset!",
            "Life is like a puzzle - sometimes you need to flip it over and start from scratch!",
            "Why be a shooting star when you can be a supernova? Shine bright and explode with brilliance!",
            "If life hands you a guitar, strum your troubles away and make some music!",
            "Don't just dream of flying, build a rocket and blast off into the unknown!",
            "Be the unicorn in a world of horses - unique, magical, and absolutely fabulous!",
            "Life is like a song - dance to your own beat and sing like nobody's listening!",
            "Why be a pebble on the beach when you can be a sandcastle? Build your dreams with love and imagination!",
            "If life hands you a paintbrush, splash color on the canvas and create your own masterpiece!",
            "Don't just follow the crowd, start a parade and lead the way!",
            "Be the light in a world of shadows - shine bright and illuminate the darkness!",
            "Life is like a rollercoaster - embrace the twists and turns and enjoy the ride!",
            "Why be a clock when you can be a time traveler? Explore the past, live in the present, and dream of the future!",
            "If life hands you a microphone, sing like nobody's listening and dance like nobody's watching!",
            "Don't just chase dreams, build castles in the sky and invite everyone to the party!",
            "Be the rainbow sprinkles on the ice cream cone of life - colorful, joyful, and absolutely delightful!",
            "Life is like a book - write your own story and make it a bestseller!",
            "Why be a candle in the dark when you can be a fireworks show? Light up the sky with your brilliance!",
            "If life hands you a guitar, strum a melody of joy and serenade the world!",
            "Don't just wish upon a star, grab a rocket and shoot for the moon!",
            "Be the sunshine in a world of clouds - warm, bright, and full of possibilities!",
            "Life is like a dance floor - move to the rhythm of your own heartbeat and dance like nobody's watching!",
            "Why be a grain of sand when you can be a pearl? Shine bright and embrace your inner beauty!",
            "If life hands you a trumpet, blow your own horn and make some noise!",
            "Don't just climb mountains, move them with sheer determination and unstoppable enthusiasm!",
            "Be the laughter in a world of tears - spread joy wherever you go!",
            "Life is like a pizza - sometimes you need to add extra cheese and spice things up!",
            "Why be a piece of the puzzle when you can be the whole picture? Create your own masterpiece!",
            "If life hands you a pineapple, make pina coladas and have a luau!",
            "Don't just aim for the stars, build a rocket and launch yourself into the galaxy!",
            "Be the laughter in a world of tears - spread joy wherever you go!"
        };

        public static string GetQuote()
        {
            return quotes[random.Next(0, quotes.Length)];
        }
    }
}
