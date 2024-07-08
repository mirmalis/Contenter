javascript:(function() {
    const host = "https://sars.lt";
  
    async function POST(identifier) {
      const url = `${host}/api/content?identifier=${identifier}`;
    
      try {
        const response = await fetch(url, {
          method: 'POST',
          headers: {
            'accept': 'text/plain',
          },
          body: ''
        });
  
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
  
        let text = await response.text();
  
        // Check if the response might be wrapped in quotes
        if (text.startsWith('"') && text.endsWith('"')) {
          text = text.slice(1, -1);
        }
  
        console.log(`${host}/c/contents/${text}`); // Print the result URL
  
      } catch (error) {
        console.error('Error:', error);
      }
    }
  
    (async function() {
      await POST(document.location.href);
    })();
  })();
  