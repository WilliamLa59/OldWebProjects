document.getElementById('PostForm').addEventListener('submit', urlPost);

const api_url = 'https://infinite-lake-01589.herokuapp.com/api/url/shorten';

async function urlPost(event) {
    event.preventDefault();
    
    let longUrl = document.getElementById('longUrl').value;
    const Url = { longUrl };
    //console.log(Url);

    const postOptions = {
        method: 'POST',
        //mode: "no-cors",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(Url)
    }

    const res = await fetch(api_url, postOptions);
    const data = await res.json();
    const { shortUrl } = data;

    document.getElementById('newUrl').value = shortUrl;
}

let copyText = document.querySelector(".copy-text");
copyText.querySelector("button").addEventListener("click", function() {
    let input = copyText.querySelector("input.text");
    input.select();
    document.execCommand("copy");
    copyText.classList.add("active");
    window.getSelection().removeAllRanges();
    setTimeout(function(){
        copyText.classList.remove("active");
    },2500);
});

