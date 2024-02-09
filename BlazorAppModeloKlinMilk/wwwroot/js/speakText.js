window.speakText = function(message) {
    var synth = window.speechSynthesis;
    var utterance = new SpeechSynthesisUtterance(message);
    synth.speak(utterance);
};