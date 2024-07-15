javascript: (function () {
  const host = "https://sars.lt";
  const open = true;
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
      let href = `${host}/c/contents/${text}`;
      if (open) {
        window.open(href, '_blank');
      }
      console.log(href);

    } catch (error) {
      console.error('Error:', error);
    }
  }
  (async function () {
    await POST(document.location.href);
  })();
})();
