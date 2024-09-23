const host = 'https://sars.lt';
async function POST(identifier) {
  const url = `${host}/api/content?identifier=${identifier}`;
  try {
    const response = await fetch(url, { method: 'POST', headers: { 'accept': 'text/plain' }, body: '' });
    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`)
    }
    let text = await response.text();
    if (text.startsWith('\"') && text.endsWith('\"')) {
      text = text.slice(1, -1)
    }
    let href = `${host}/c/contents/${text}`;
    window.open(href, '_blank');
    console.log(href)
  } catch (error) {
    console.error('Error:', error)
  }
}
(async function () {
  await POST(document.location.href);
})();
